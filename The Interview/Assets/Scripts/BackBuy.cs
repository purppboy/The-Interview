using UnityEngine;
using UnityEngine.EventSystems;

public class BackBuy : MonoBehaviour ,IPointerDownHandler
{
    public GameObject buyBig;

    public void OnPointerDown(PointerEventData eventData)
    {
        int position = PlayerPrefs.GetInt("buyPos");
        
        if (position == 0)
        {
            PlayerPrefs.SetInt("buyPos", OutfitHelper.OutfitsArray().Length-1);
        }
        else
        {
            PlayerPrefs.SetInt("buyPos",position-1);
        }
        
        buyBig.GetComponent<BuyBig>().SetOutfits();
    }
}
