using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardSell : MonoBehaviour, IPointerDownHandler
{
    
    public GameObject sellBig;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        int sellPosition = PlayerPrefs.GetInt("sellPos");
        
        
        if (sellPosition == OutfitHelper.BoughtOutfits().Count-1)
        {
            PlayerPrefs.SetInt("sellPos",1);
        }
        else
        {
            PlayerPrefs.SetInt("sellPos",sellPosition+1);
        }
        
        
        sellBig.GetComponent<SellBig>().SetOutfits();
    }
}