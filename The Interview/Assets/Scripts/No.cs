using UnityEngine;
using UnityEngine.EventSystems;

public class No : MonoBehaviour, IPointerDownHandler
{
    public GameObject popUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        popUp.SetActive(false);
    }
}
