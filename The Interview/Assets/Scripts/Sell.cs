using UnityEngine;

public class Sell : MonoBehaviour
{
    public GameObject sell;

    public GameObject buy;

    private void OnMouseDown()
    {
        HideBuySell();
    }

    public void HideBuySell()
    {
        sell.SetActive(false);
        buy.SetActive(false);
    }
}