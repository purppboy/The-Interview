using UnityEngine;
using UnityEngine.UI;

public class PopUpAddClick : MonoBehaviour
{
    public GameObject popUp;
    
    private void OnEnable()
    {
        popUp.GetComponent<Image>().alphaHitTestMinimumThreshold = 0;
    }

}
