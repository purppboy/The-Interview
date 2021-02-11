using UnityEngine;
using UnityEngine.EventSystems;

public class SellButtonBig : MonoBehaviour,IPointerDownHandler
{
    public GameObject sellBig;

    public void OnPointerDown(PointerEventData eventData)
    {
        sellBig.SetActive(true);
    }
}
