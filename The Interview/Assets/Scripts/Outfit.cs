[System.Serializable]
public class Outfit
{
    public bool isSelected;
    public int priceOutfit;
    public int priceOutfitSell;
    public bool isBought;


    public Outfit(int i)
    {
        SetPrices(i);
    }

    
    private void SetPrices(int i)
    {
        switch(i) 
        {
            case 0:
                
                isBought = true;
                isSelected = true;
                break;
            case 1:
                priceOutfit = 36;
                break;
            case 2:
                priceOutfit = 78;
                break;
            case 3:
                priceOutfit = 99;
                
                break;
        }
        priceOutfitSell = priceOutfit -10;
        
    }


}