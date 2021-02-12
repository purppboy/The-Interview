using UnityEngine;

public class BuyBig : MonoBehaviour
{
    public GameObject sellBig;

    public GameObject[] outfitGameObjects;

    public GameObject[] outfitPrices;

    public GameObject select;

    public GameObject current;

    public GameObject[] equipPrices;

    public GameObject[] tickSmall;

    public GameObject tickBig;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("buyPos", OutfitHelper.SelectedOutfitPos());
    }

    private void OnEnable()
    {
        sellBig.SetActive(false);
        
        SetOutfitsAndEquip();
    }

    public void SetOutfitsAndEquip()
    {
        
        int position = PlayerPrefs.GetInt("buyPos");
        Outfit outfit = OutfitHelper.OutfitAtPos(position);

        SetOutfits(position, outfit);
        SetEquip(outfit);
    }

    private void SetOutfits(int position, Outfit outfit)
    {
        //Outfit
        for (int i = 0; i < outfitGameObjects.Length; i++)
        {
            if (i == position)
            {
                outfitGameObjects[i].SetActive(true);
            }
            else
            {
                outfitGameObjects[i].SetActive(false);
            }
        }


        //Price
        if (!outfit.isBought)
        {
            //0 is fake coz of default outfit 
            for (int i = 0; i < outfitPrices.Length; i++)
            {
                if (i == position)
                {
                    outfitPrices[i].SetActive(true);
                }
                else
                {
                    outfitPrices[i].SetActive(false);
                }
            }


            select.SetActive(false);
            current.SetActive(false);
        }
        else if (outfit.isSelected)
        {
            current.SetActive(true);
            select.SetActive(false);
            HidePrices();
        }
        else if (outfit.isBought && !outfit.isSelected)
        {
            select.SetActive(true);
            current.SetActive(false);
            HidePrices();
        }


        //Tick
        if (outfit.isSelected)
        {
            tickBig.SetActive(true);
        }
        else
        {
            tickBig.SetActive(false);
        }
    }

    private void SetEquip(Outfit outfit)
    {
        for (int i = 0; i < equipPrices.Length; i++)
        {
            bool selected = outfit.EquipIsSelected(i);
            bool bought = outfit.EquipIsBought(i);
            
            if (bought && !selected)
            {
                tickSmall[i].SetActive(false);
                equipPrices[i].SetActive(false);
            }
            else if (selected)
            {
                tickSmall[i].SetActive(true);
                equipPrices[i].SetActive(false);
            }
            //Not bought
            else
            {
                tickSmall[i].SetActive(false);
                equipPrices[i].SetActive(true);
                
            }
        }
    }

    private void HidePrices()
    {
        foreach (var price in outfitPrices)
        {
            price.SetActive(false);
        }
    }
}