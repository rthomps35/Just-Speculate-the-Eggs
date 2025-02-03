using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using TMPro;
using System.Runtime.ExceptionServices;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	//Timer
	[SerializeField] double currentSeconds;
	public int totalTics;
	public int TicInterval;
	public int NewsTicInterval;
	[SerializeField] int newsTics;
	[SerializeField] int newsCounter;

	//Commodities
	public List<Commodity> Commodities;	//The list of Commodities

	public enum MarketState { Normal, Bubble, Collapse}
	public MarketState CurrentMarketState;
	public int BubbleFormationTic;
	
	
	public double PlayerMoney;

	#region News
	//News should be a stack of cards
	//None of this shit is needed. I think what I'm going to do is have another news count
	//List of unused news
	public List<NewsEvent> UnusedNormalEvents;
	public List<NewsEvent> UsedNormalEvents;
	public List<NewsEvent> UnusedBubblelEvents;
	public List<NewsEvent> UsedBubbleEvents;
	//List of used?
	//List of 
	[SerializeField] NewsEvent FirstNewsEvent;	//So the game always starts in the same state
	[SerializeField] NewsEvent CurrentNewsEvent;
	[SerializeField] NewsEvent LastNewsEvent;   //So the game always ends in the same state?
	[SerializeField] NewsEvent News;
	
	
	
	#endregion

	#region UI Items
	[SerializeField] TextMeshProUGUI PlayerMoneyText;
	[SerializeField] TextMeshProUGUI NewsText;
	[SerializeField] Image NewsImage;
	#endregion

	#region audio
	[SerializeField] AudioSource GameMusic;
	[SerializeField] AudioClip MainMusic;
	[SerializeField] AudioClip BubbleMusic;
	[SerializeField] AudioClip CollapseMusic;
	[SerializeField] AudioClip PostMusic;
	#endregion

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		
        foreach(Commodity commodity in Commodities)
		{
			commodity.CommodityPrice = commodity.OriginalPrice;
			commodity.UISetUp();
		}
		totalTics = 1;
		//base tic interval?

		//BubbleFormationTic = Random.Range(18,36); //bubble formation time, assumes 10 second tics
		
		News.SetUpEvent(1);

		//UI Updates
		UINewsUpdate();
		UIPlayerCash();
		
	}

    // Update is called once per frame
    void Update()
    {
		TicUpdate();
        
    }

	void TicUpdate()
	{
		currentSeconds += Time.deltaTime;
		//Count to tic interval
		if (currentSeconds >= TicInterval)
		{
			PriceUpdate();  //Update the price
			currentSeconds = 0;
			totalTics++;
			newsTics++;

			//new news needs to come in
			if (newsTics >= NewsTicInterval)
			{
				//new news
				newsTics = 0;
				newsCounter ++;
				//Skip relevent numbers
				if(newsCounter == 7)
				{
					CurrentMarketState = MarketState.Bubble;
					TicInterval = 2;
					NewsTicInterval = 3;
					Debug.Log("We are in a bubble");
					newsCounter = 11;
					Debug.Log(newsCounter);
					//change music
				}
				else if(newsCounter == 17)
				{
					CurrentMarketState = MarketState.Collapse;
					TicInterval = 2;
					Debug.Log("Oh god");
					newsCounter = 21;
					//change music
				}
				else if(newsCounter == 26)
				{
					//End Game
					//kick to another screen or pull up the UI?
					//change music
					SceneManager.LoadScene("End");
				}
				
				//clear the modifier from the old ones
				foreach (Commodity c in Commodities)
				{
					c.NewsModifier = 0;
				}
				//instantiate new news story
				
				News.SetUpEvent(newsCounter);
				//if effects everyone
				if (News.EffectWholeMarket == true)
				{
					foreach (Commodity c in Commodities)
					{
						c.NewsModifier = News.PriceModifier;
					}
				}
				else
				{
					Debug.Log(News.ImpactedCommodity);
					News.ImpactedCommodity.NewsModifier = News.PriceModifier;
				}
				UINewsUpdate();

			}
			
			
			UpdateUI(); //update UI
		}

	}

	//Price Update
	void PriceUpdate()
	{
				
		foreach (Commodity C in Commodities)
		{
			double priceChange = 0; 
			double NewCommodityPrice = 0;

			if (CurrentMarketState == MarketState.Normal)
			{

				//Before it was modifer, now it will be something added to the pricechange
				
				priceChange = Random.Range(-3, 3);  //So this is the normal shift. I should have one that modifies it based on the news
				
			}
			else if (CurrentMarketState == MarketState.Bubble)
			{
				//insane growth
				priceChange = Random.Range(10, 200); //Just insane gains
			}
			else if (CurrentMarketState == MarketState.Collapse)
			{
				//lol
				//Everything should drop -1 to -100%
				priceChange = Random.Range(-100, -5);
			}

			NewCommodityPrice = C.CommodityPrice + (C.CommodityPrice * ((priceChange + C.NewsModifier) / 100));
			NewCommodityPrice = Math.Round(NewCommodityPrice, 2);
			Debug.Log(C.CommodityName + " changed: " + priceChange + "%");

			C.UIPanelChange(NewCommodityPrice);
			C.CommodityPrice = NewCommodityPrice;	//Should already be rounded
			C.UIUpdate();


		}

	}


	//Buy
	public void BuyEggs(Commodity C)
	{
		
		PlayerMoney -= C.CommodityPrice;
		C.PlayerShares += 12;	//Lets be honest, we are buy dozen's of eggs
		//price jumps a 1%
		C.UIUpdate();//update price UI
		UIPlayerCash();//update player UI
		//play commodity buy noise
	}
		
	//Sell
	public void SellEggs(Commodity C)
	{
		if(C.PlayerShares >= 12)
		{
			PlayerMoney += C.CommodityPrice;
			C.PlayerShares -= 12;
			C.UIUpdate();//update price UI
			UIPlayerCash();//update player UI


			//I want some way to lower price?
			//play commodity sell noise
		}
		else
		{
			//play not enough eggs
		}
	}

	void UpdateUI()
	{
		//Update all the UI Elements
		//Doesn't seem right???
		UIPlayerCash();
	}



	void UINewsUpdate()
	{
		NewsImage.sprite = News.NewsPicture;//Picture
		NewsText.text = News.NewsText; //Text	
		
	}

	void UIPlayerCash()
	{
		Math.Round(PlayerMoney, 2);
		PlayerMoneyText.text = $"Bank Account Balance: ${PlayerMoney}";
	}


	void EndGame()
	{
		SceneManager.LoadScene("MainMenu");
	}

	void NewNewsStory()
	{
		//tic
		if (News.ImpactedCommodity != null)
		{

		}
		else
		{
			//apply it to everyone?
		}
	}



	
	
	



}
