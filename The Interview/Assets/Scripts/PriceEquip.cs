using UnityEngine;
using UnityEngine.EventSystems;

public class PriceEquip : MonoBehaviour, IPointerDownHandler
{
    public GameObject popUpYes;
    public int position;
    public GameObject popUp;
    public GameObject popUpInsufficient;
    public GameObject popUpBuyFirst;
    public GameObject buyBig;

    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).equips[position].isBought)
        {
            
            if (OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).isBought)
            {
                if (PlayerPrefs.GetInt("cash") <
                    OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).equips[position].equipPrice)
                {
                    popUpInsufficient.SetActive(true);
                }
                else
                {
                    popUpYes.GetComponent<PopUpBuyYes>().PopUpEquips(position);
                    popUp.SetActive(true);
                }
            }
            else
            {
                popUpBuyFirst.SetActive(true);
            }
        }
        else if (OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).equips[position].isBought &&
                 OutfitHelper.OutfitAtPos(PlayerPrefs.GetInt("buyPos")).equips[position].isSelected)
        {
            OutfitHelper.SetEquipIsSelected(position,false);
            buyBig.GetComponent<BuyBig>().SetOutfitsAndEquip();
        }
        else 
        {
            OutfitHelper.SetEquipIsSelected(position,true);
            buyBig.GetComponent<BuyBig>().SetOutfitsAndEquip();
        }
    }
}