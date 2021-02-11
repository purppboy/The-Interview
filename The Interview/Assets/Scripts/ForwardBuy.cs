using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardBuy : MonoBehaviour ,IPointerDownHandler
{
    public GameObject buyBig;
    

    public void OnPointerDown(PointerEventData eventData)
    {
       
        int position = PlayerPrefs.GetInt("buyPos");
        
        if (position == OutfitHelper.OutfitsArray().Length-1)
        {
            PlayerPrefs.SetInt("buyPos",0);
        }
        else
        {
            PlayerPrefs.SetInt("buyPos",position+1);
        }
        
        buyBig.GetComponent<BuyBig>().SetOutfits();
    }
}
