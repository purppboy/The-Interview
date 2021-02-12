using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class OutfitHelper
{
    public static void Save(Outfit[] outfits)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/outfits.ot");
        bf.Serialize(file, outfits);
        file.Close();
    }

    public static Outfit[] OutfitsArray()
    {
        Outfit[] theOutfitsArray = { };

        if (File.Exists(Application.persistentDataPath + "/outfits.ot"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/outfits.ot", FileMode.Open);
            theOutfitsArray = (Outfit[]) bf.Deserialize(file);
            file.Close();
        }

        return theOutfitsArray;
    }

    public static int SelectedOutfitPos()
    {
        Outfit[] outfits = OutfitsArray();

        int pos = 0;

        for (var i = 0; i < outfits.Length; i++)
        {
            Outfit outfit = outfits[i];
            if (outfit.isSelected)
            {
                pos = i;
                break;
            }
        }

        return pos;
    }

    public static Outfit SelectedOutfit()
    {
        Outfit[] outfits = OutfitsArray();

        return outfits[SelectedOutfitPos()];
    }

    public static Outfit OutfitAtPos(int position)
    {
        return OutfitsArray()[position];
    }

    public static void SetOutfitIsSelected(int position)
    {
        Outfit[] outfits = OutfitsArray();

        for (int i = 0; i < outfits.Length; i++)
        {
            Outfit outfit = outfits[i];
            if (i == position)
            {
                outfit.isSelected = true;
            }
            else
            {
                outfit.isSelected = false;
            }

            outfits[i] = outfit;
        }

        Save(outfits);
    }

    public static void SetOutfitIsBought(int position, bool isBought)
    {
        Outfit[] outfits = OutfitsArray();

        Outfit outfit = outfits[position];
        outfit.isBought = isBought;

        outfits[position] = outfit;

        Save(outfits);
    }

    public static void SetEquipIsBought(int equipPos)
    {
        Outfit[] outfits = OutfitsArray();

        Outfit outfit = outfits[PlayerPrefs.GetInt("buyPos")];

        outfit.equips[equipPos].isBought = true;

        outfits[PlayerPrefs.GetInt("buyPos")] = outfit;


        Save(outfits);

        SetEquipIsSelected(equipPos, true);
    }

    public static void SetEquipIsSelected(int equipPos, bool isSelected)
    {
        Outfit[] outfits = OutfitsArray();

        Outfit outfit = outfits[PlayerPrefs.GetInt("buyPos")];

        outfit.equips[equipPos].isSelected = isSelected;

        outfits[PlayerPrefs.GetInt("buyPos")] = outfit;


        Save(outfits);
    }

    public static List<int> BoughtOutfits()
    {
        List<int> boughtOutfits = new List<int>();
        
        for (int i = 0; i < OutfitsArray().Length; i++)
        {
            if (OutfitAtPos(i).isBought)
            {
                boughtOutfits.Add(i);
            }

        }

        return boughtOutfits;
    }
}