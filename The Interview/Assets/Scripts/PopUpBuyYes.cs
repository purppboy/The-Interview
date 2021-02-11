using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpBuyYes : MonoBehaviour, IPointerDownHandler
{
    public GameObject buyBig;

    public GameObject popUp;
    
    

    public void OnPointerDown(PointerEventData eventData)
    {
        
        int cash = PlayerPrefs.GetInt("cash") -
                   OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).priceOutfit;

        OutfitHelper.SetOutfitIsBought(PlayerPrefs.GetInt("buyPos"), true);

        PlayerPrefs.SetInt("cash", cash);

        
        
        
        int outfitNo = PlayerPrefs.GetInt("outfitNo") + 1;

        PlayerPrefs.SetInt("outfitNo", outfitNo);


        buyBig.GetComponent<BuyBig>().SetOutfits();

        popUp.SetActive(false);
    }
}