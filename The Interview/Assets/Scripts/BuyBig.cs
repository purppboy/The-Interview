using UnityEngine;

public class BuyBig : MonoBehaviour
{
    public GameObject sellBig;

    public GameObject[] outfitGameObjects;

    public GameObject[] outfitPrices;

    public GameObject select;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("buyPos", OutfitHelper.SelectedOutfitPos());
    }
    private void OnEnable()
    {
        sellBig.SetActive(false);

        SetOutfits();
    }


    public void SetOutfits()
    {
        int position = PlayerPrefs.GetInt("buyPos");
        Outfit outfit = OutfitHelper.OutfitAtPos(position);
        
        
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
        }
        else if (outfit.isSelected)
        {
            select.SetActive(false);
            HidePrices();
        }
        else if (outfit.isBought && !outfit.isSelected)
        {
            select.SetActive(true);
            HidePrices();
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