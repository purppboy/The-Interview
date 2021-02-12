using System.Collections;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject boy;

    private float _distance;

    public Sprite shop1;
    public Sprite shop2;

    private SpriteRenderer _spriteRenderer;

    public GameObject[] talkAndBuy;
    public GameObject buy;
    public GameObject sell;
    public GameObject talkBoy;
    public GameObject talkShop1;
    public GameObject talkShop2;
    public GameObject buyMain;
    public GameObject sellMain;
    public bool buyInProgress;


    private const float DistanceBetween = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        buyInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeShop();
        Conversation();
    }

    private void Conversation()
    {
        if (Input.GetKeyDown(KeyCode.E) && !buyInProgress && _distance < DistanceBetween && !buyMain.activeInHierarchy &&
            !sellMain.activeInHierarchy)
        {
            StartCoroutine(ConversationHideShow());
        }
    }

    private IEnumerator ConversationHideShow()
    {
        buyInProgress = true;

        if (buyInProgress)
        {
            talkShop1.SetActive(true);
        }
        else
        {
            HideTalkAndBuy();
            yield break;
        }

        yield return new WaitForSeconds(4f);

        if (buyInProgress)
        {
            talkShop1.SetActive(false);

            talkBoy.SetActive(true);
        }
        else
        {
            HideTalkAndBuy();
            yield break;
        }


        yield return new WaitForSeconds(4f);

        if (buyInProgress)
        {
            talkBoy.SetActive(false);
            talkShop2.SetActive(true);
        }
        else
        {
            HideTalkAndBuy();
            yield break;
        }


        yield return new WaitForSeconds(4.5f);

        if (buyInProgress)
        {
            talkShop2.SetActive(false);

            buy.SetActive(true);
            sell.SetActive(true);
        }
        else
        {
            HideTalkAndBuy();
        }
    }

    private void ChangeShop()
    {
        _distance = Vector3.Distance(boy.transform.position, transform.position);

        Sprite theSprite = _spriteRenderer.sprite;

        if (_distance < DistanceBetween && theSprite == shop1)
        {
            _spriteRenderer.sprite = shop2;
        }
        else if (_distance > DistanceBetween && theSprite == shop2)
        {
            _spriteRenderer.sprite = shop1;
            buyInProgress = false;

            HideTalkAndBuy();
        }
    }

    private void HideTalkAndBuy()
    {
        foreach (var talkGameObject in talkAndBuy)
        {
            if (talkGameObject.activeInHierarchy)
            {
                talkGameObject.SetActive(false);
            }
        }
    }
}