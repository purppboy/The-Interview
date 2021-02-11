using UnityEngine;

public class SellBig : MonoBehaviour
{
    public GameObject buyBig;

    private void OnEnable()
    {
        buyBig.SetActive(false);
    }
}
