using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Commodity : MonoBehaviour
{
    public Sprite CommodityPicture;	//Picture of the commodity for the UI
	public Sprite ChangeIndecator;
	public string CommodityName;	//Commodity Name
	public double OriginalPrice;	//The price it "should be at"
	public double CommodityPrice;   //Needs to be flattened to the second position
	public int PlayerShares;        //Shares Owned By Player
	public string Ticker;
	
	public double NewsModifier;
	

	#region
	//UI Items
	[SerializeField] Image PanelUIImage;
	//BuyButton
	[SerializeField] TextMeshProUGUI BuyButtonText;
	//[SerializeField] Button SellButton;     //SellButton
	[SerializeField] TextMeshProUGUI SellButtonText;	
	[SerializeField] TextMeshProUGUI CName;	//CommodityName
	//CommodityIndicator????????
	[SerializeField] TextMeshProUGUI PriceText; //current price
	[SerializeField] TextMeshProUGUI SharesText;	//current shares
	#endregion

	public void UISetUp()
	{ 
		//Ticker??
		CName.text = $"{Ticker}: {CommodityName}";
		BuyButtonText.text = $"Buy 12 {Ticker}";
		SellButtonText.text = $"Sell 12 {Ticker}";
		PriceText.text = $"${CommodityPrice}";
		SharesText.text = $"Owned: {PlayerShares}";
		UIPanelChange(OriginalPrice);
	}

	//Commodity UI Items
	public void UIUpdate()
	{
		PriceText.text = $"${CommodityPrice}";
		SharesText.text = $"Owned: {PlayerShares}";	//Shares update
	}

	public void  UIPanelChange(double NewPrice)
	{
		if (NewPrice > CommodityPrice)
		{
			//UP
			//Gonna keep the UI clean and just make the panel green
			PanelUIImage.color = Color.green;
		}
		else if (NewPrice == CommodityPrice)
		{
			//Stagnate
			PanelUIImage.color = Color.gray;
		}
		else
		{
			//Down
			PanelUIImage.color = Color.red;
		}
	}

}
