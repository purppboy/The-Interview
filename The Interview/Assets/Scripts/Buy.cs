using UnityEngine;

public class Buy : MonoBehaviour
{
    public GameObject sell;
    
    private void OnMouseDown()
    {
        sell.GetComponent<Sell>().HideBuySell();
    }
    
}
