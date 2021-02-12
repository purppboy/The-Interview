using UnityEngine;
using UnityEngine.EventSystems;

public class PriceOutfitSell : MonoBehaviour,IPointerDownHandler
{
    public GameObject popUpSell;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        popUpSell.SetActive(true);
    }
}