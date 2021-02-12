using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpBuyYes : MonoBehaviour, IPointerDownHandler
{
    private bool _isEquips;

    private int _position;

    public GameObject cashText;

    public GameObject outfitText;
    
    public GameObject buyBig;
    
    public GameObject popUp;
    

    public void PopUpEquips(int pos)
    {
        
        _position = pos;
        _isEquips = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isEquips)
        {
            //cash
            int cash = PlayerPrefs.GetInt("cash") -
                       OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).equips[_position].equipPrice;
            
            OutfitHelper.SetEquipIsBought(_position);
            
            PlayerPrefs.SetInt("cash", cash);

            cashText.GetComponent<TextMeshProUGUI>().text = cash.ToString();
        }
        else
        {
            //cash
            int cash = PlayerPrefs.GetInt("cash") -
                       OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).priceOutfit;
            
            OutfitHelper.SetOutfitIsBought(PlayerPrefs.GetInt("buyPos"),true);
            
            PlayerPrefs.SetInt("cash", cash);
            
            cashText.GetComponent<TextMeshProUGUI>().text = cash.ToString();
            
            //outfit no
            int outfitNo = PlayerPrefs.GetInt("outfitNo") + 1;
            
            PlayerPrefs.SetInt("outfitNo", outfitNo);
            
            outfitText.GetComponent<TextMeshProUGUI>().text = outfitNo.ToString();

        }

        _isEquips = false;
        
        buyBig.GetComponent<BuyBig>().SetOutfitsAndEquip();
        
        popUp.SetActive(false);
    }
}