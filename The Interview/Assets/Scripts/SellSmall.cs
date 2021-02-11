using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SellSmall : MonoBehaviour
{
    public GameObject sellSmall;

    public GameObject buySmall;

    public GameObject sellBig;

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
}