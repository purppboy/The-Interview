using UnityEngine;

public class BuySmall : MonoBehaviour
{
    public GameObject buyBig;

    public GameObject sellSmall;
    
    private void OnMouseDown()
    {
        buyBig.SetActive(true);
        sellSmall.GetComponent<SellSmall>().HideBuySellSmall();
    }
    
}
