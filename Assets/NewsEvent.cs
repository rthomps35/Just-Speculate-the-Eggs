using System;
using System.Diagnostics;
using Unity.Burst.CompilerServices;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewsEvent : MonoBehaviour
{
    public Commodity? ImpactedCommodity;	//Made nullable so I can do general stuff?:
	public double PriceModifier;
	public string NewsText;
	public Sprite NewsPicture;
	public bool EffectWholeMarket;

	public Commodity White;
	public Commodity Brown;
	public Commodity Crow;

	[SerializeField] Sprite N01;
	[SerializeField] Sprite N02;
	[SerializeField] Sprite N03;
	[SerializeField] Sprite N04;
	[SerializeField] Sprite N05;
	[SerializeField] Sprite N06;
	[SerializeField] Sprite N11;
	[SerializeField] Sprite N12;
	[SerializeField] Sprite N13;
	[SerializeField] Sprite N14;
	[SerializeField] Sprite N15;
	[SerializeField] Sprite N16;
	[SerializeField] Sprite N21;
	[SerializeField] Sprite N22;
	[SerializeField] Sprite N23;
	[SerializeField] Sprite N24;
	[SerializeField] Sprite N25;

	//There will be only one event and it will be updated in here
	public void SetUpEvent(int eventNumber)
	{
		
		
		
		switch (eventNumber)
		{
			case 1:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText= "Nothing could be more normal in the Egg market!";
				NewsPicture = N01;
				EffectWholeMarket = true;
				break;
			case 2:
				ImpactedCommodity = FindCommodity();
				PriceModifier = 10;
				NewsText = $"Goblins raid multiple coops, {ImpactedCommodity.CommodityName} prices set to increase.";
				NewsPicture = N02;
				EffectWholeMarket = false;
				break;
			case 3:
				ImpactedCommodity = FindCommodity();
				PriceModifier = -10;
				NewsText = $"China increases target for {ImpactedCommodity.CommodityName} in 5-Year Plan. Prices to decrease.";
				NewsPicture = N03;
				EffectWholeMarket = false;
				break;
			case 4:
				ImpactedCommodity = FindCommodity();
				PriceModifier = 15;
				NewsText = $"Celebrity shares lifestyle: \"I wake up every day and open palm slam {ImpactedCommodity.CommodityName} into the VCR. Then I lift\"";
				NewsPicture = N04;
				EffectWholeMarket = false;
				break;
			case 5:
				ImpactedCommodity = FindCommodity();
				PriceModifier = 10;
				NewsText = $"Hot new scrambled {ImpactedCommodity.CommodityName} recipe takes nation by storm.";
				NewsPicture = N05;
				EffectWholeMarket = false;
				break;
			case 6:
				ImpactedCommodity = FindCommodity();
				PriceModifier = -15;
				NewsText = $"No one wants {ImpactedCommodity.CommodityName} anymore. Millennials and Zoomers to blame.";
				NewsPicture = N06;
				EffectWholeMarket = false;
				break;
			case 11:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "Eggs could replace dollar!";
				NewsPicture = N11;
				EffectWholeMarket = true;
				break;
			case 12:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "There is nowhere for the price of Eggs to go but up!";
				NewsPicture = N12;
				EffectWholeMarket = true;
				break;
			case 13:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "\"I can't die eggless!!!\" Hot new anxiety sweeping the nation";
				NewsPicture = N13;
				EffectWholeMarket = true;
				break;
			case 14:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "Silicon Valley newest craze is Eggs on the blockchain";
				NewsPicture = N14;
				EffectWholeMarket = true;
				break;
			case 15:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "A lotta yall still dont get it. You can use multiple slurp juices on a single egg";
				NewsPicture = N15;
				EffectWholeMarket = true;
				break;
			case 16:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "This can't be sustainable, in this 300 post thread I...";
				NewsPicture = N16;
				EffectWholeMarket = true;
				break;
			case 21:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "Did the Egg bubble burst? No, the market has always been like this.";
				NewsPicture = N21;
				EffectWholeMarket = true;
				break;
			case 22:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "There is absolutely no need to panic!";
				NewsPicture = N22;
				EffectWholeMarket = true;
				break;
			case 23:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "Capitalism is the most rational system that has ever existed. This is a minor correction.";
				NewsPicture = N23;
				EffectWholeMarket = true;
				break;
			case 24:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "We pissed in the face of God and she is very angry";
				NewsPicture = N24;
				EffectWholeMarket = true;
				break;
			case 25:
				ImpactedCommodity = null;
				PriceModifier = 0;
				NewsText = "\"Look upon my market ye mighty and despair!\" Nothing else on the ticker remains...";
				NewsPicture = N25;
				EffectWholeMarket = true;
				break;

		}
	}

	Commodity FindCommodity()
	{
		int index = Random.Range(0, 2);

		switch (index)
		{
			case 0:
				return White;
			case 1:
				return Brown;
			case 2:
				return Crow;
			default:
				return null;
		}
	}
		
}
