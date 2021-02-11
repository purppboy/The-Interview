using UnityEngine;
using UnityEngine.EventSystems;

public class Exit : MonoBehaviour,IPointerDownHandler
{
    public GameObject buyBig;

    public GameObject sellBig;
    
    public GameObject boy;
    

    public void OnPointerDown(PointerEventData eventData)
    {
        buyBig.SetActive(false);
        sellBig.SetActive(false);
        
        
        PlayerPrefs.SetInt("buyPos",OutfitHelper.SelectedOutfitPos());
        
        boy.GetComponent<Boy>().SetOutfit();


    }
}
