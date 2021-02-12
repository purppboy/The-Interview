using UnityEngine;
using UnityEngine.EventSystems;

public class OutfitClick : MonoBehaviour,IPointerDownHandler
{
    public GameObject popUpInsufficient;
    public GameObject buyBig;
    public GameObject popUpBuy;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (!OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).isBought)
        {
            if (PlayerPrefs.GetInt("cash") < OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).priceOutfit)
            {
                popUpInsufficient.SetActive(true);
            }
            else
            {
                popUpBuy.SetActive(true);
            }
        }
        else if (OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).isBought &&
                 !OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).isSelected)
        {
            OutfitHelper.SetOutfitIsSelected(PlayerPrefs.GetInt("buyPos"));
            buyBig.GetComponent<BuyBig>().SetOutfitsAndEquip();
        }
    }
}