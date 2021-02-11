using UnityEngine;
using UnityEngine.EventSystems;

public class PriceOutfit : MonoBehaviour,IPointerDownHandler
{
    public GameObject popUpInsufficient;
    public GameObject popUpBuy;
    
    public void OnPointerDown(PointerEventData eventData)
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
}