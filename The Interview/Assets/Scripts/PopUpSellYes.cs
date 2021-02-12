using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpSellYes : MonoBehaviour, IPointerDownHandler
{
    public GameObject cashText;

    public GameObject outfitText;
    
    public GameObject sellBig;
    
    public GameObject popUp;
    
    
    public void OnPointerDown(PointerEventData eventData)
    { 
        
        //cash
        int cash = PlayerPrefs.GetInt("cash") +
                   OutfitHelper.OutfitAtPos(OutfitHelper.BoughtOutfits()[PlayerPrefs.GetInt("sellPos")]).priceOutfitSell;

        if (OutfitHelper.OutfitAtPos(OutfitHelper.BoughtOutfits()[PlayerPrefs.GetInt("sellPos")]).isSelected)
        {
            OutfitHelper.SetOutfitIsSelected(0);
            PlayerPrefs.SetInt("buyPos", OutfitHelper.SelectedOutfitPos());
        }
        
        OutfitHelper.SetOutfitIsBought(OutfitHelper.BoughtOutfits()[PlayerPrefs.GetInt("sellPos")],false);
            
        PlayerPrefs.SetInt("cash", cash);
            
        cashText.GetComponent<TextMeshProUGUI>().text = cash.ToString();
            
        //outfit no
        int outfitNo = PlayerPrefs.GetInt("outfitNo") - 1;
            
        PlayerPrefs.SetInt("outfitNo", outfitNo);
            
        outfitText.GetComponent<TextMeshProUGUI>().text = outfitNo.ToString();
        
        //reset sell pos
        PlayerPrefs.SetInt("sellPos", 1);
        
        sellBig.GetComponent<SellBig>().SetOutfits();
        
        popUp.SetActive(false);
    }
}