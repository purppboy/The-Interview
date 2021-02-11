using UnityEngine;
using UnityEngine.EventSystems;

public class BuyButtonBig : MonoBehaviour,IPointerDownHandler
{
    public GameObject buyBig;
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        buyBig.SetActive(true);
    }
}
