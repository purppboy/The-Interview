[System.Serializable]
public class Outfit
{
    public bool isSelected;
    public Equips[] equips = new Equips[4];
    public int priceOutfit;
    public int priceOutfitSell;
    public bool isBought;


    //Equips Class
    [System.Serializable]
    public class Equips
    {
        public int equipPrice;
        public bool isSelected;
        public bool isBought;
        
        public Equips(int i)
        {
            SetEquipPrices(i);
        } 
        
        private void SetEquipPrices(int i)
             {
                 switch(i) 
                 {
                     case 0:
                         equipPrice = 2;
                         break;
                     case 1:
                         equipPrice = 3;
                         break;
                     case 2:
                         equipPrice = 5;
                         break;
                     case 3:
                         equipPrice = 7;
                         
                         break;
                 }
                 
             }
    }
    
   
    
    //Outfit
    public Outfit(int i)
    {
        SetPrices(i);
        SetEquips();
    }


    private void SetEquips()
    {
        for (int i = 0; i < 4; i++)
        {
            equips[i] = new Equips(i);
        }
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
            case 4:
                priceOutfit = 212;
                
                break;
        }
        priceOutfitSell = priceOutfit -10;
        
    }

    public bool EquipIsSelected(int i)
    {
        return equips[i].isSelected;
    }

    public bool EquipIsBought(int i)
    {
        return equips[i].isBought;
    }

}