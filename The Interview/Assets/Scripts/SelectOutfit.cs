using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOutfit : MonoBehaviour,IPointerDownHandler
{
    public GameObject buyBig;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        OutfitHelper.SetOutfitIsSelected(PlayerPrefs.GetInt("buyPos"));
        
        buyBig.GetComponent<BuyBig>().SetOutfitsAndEquip();
    }
}