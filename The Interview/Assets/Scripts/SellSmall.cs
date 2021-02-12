using UnityEngine;

public class SellSmall : MonoBehaviour
{
    public GameObject sellSmall;

    public GameObject buySmall;

    public GameObject sellBig;

    public GameObject shop;


    private void OnMouseDown()
    {
        sellBig.SetActive(true);
        HideBuySellSmall();
    }

    public void HideBuySellSmall()
    {
        sellSmall.SetActive(false);
        buySmall.SetActive(false);
    }

    private void OnDisable()
    {
        shop.GetComponent<Shop>().buyInProgress = false;
    }
}