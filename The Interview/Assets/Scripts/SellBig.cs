using UnityEngine;

public class SellBig : MonoBehaviour
{
    public GameObject buyBig;
    public GameObject[] outfitGameObjects;
    public GameObject[] outfitPrices;
    public GameObject backSell;
    public GameObject forwardSell;
    public GameObject nothingToSell;
    public GameObject sellOutfitsTitle;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("sellPos", 1);
    }

    
     private void OnEnable()
        {
            buyBig.SetActive(false);
            SetOutfits();
        }
    
    public void SetOutfits()
    {
        int position = PlayerPrefs.GetInt("sellPos");
        
        
        if (OutfitHelper.BoughtOutfits().Count==1)
        {
            forwardSell.SetActive(false);
            backSell.SetActive(false);

            foreach (var price in outfitPrices)
            {
                price.SetActive(false);
            }

            foreach (var outfitGameObject in outfitGameObjects)
            {
                outfitGameObject.SetActive(false);
            }
            
            nothingToSell.SetActive(true);
            sellOutfitsTitle.SetActive(false);
            
            return;
        }

        if (OutfitHelper.BoughtOutfits().Count==2)
        {
            backSell.SetActive(false);
            forwardSell.SetActive(false);
        }
        else
        {
            backSell.SetActive(true);
            forwardSell.SetActive(true);
        }
        
        nothingToSell.SetActive(false);
        sellOutfitsTitle.SetActive(true);
        
        //Outfit
        for (int i = 0; i < outfitGameObjects.Length; i++)
        {
            if (i==0)
            {
                outfitGameObjects[i].SetActive(false);
                outfitPrices[i].SetActive(false);
            }
            else
            {
                if (i == OutfitHelper.BoughtOutfits()[position])
                {
                    outfitGameObjects[i].SetActive(true);
                    outfitPrices[i].SetActive(true);
                }
                else
                {
                    outfitGameObjects[i].SetActive(false);
                    outfitPrices[i].SetActive(false);
                }
            }
            
        }

    }

   
}
