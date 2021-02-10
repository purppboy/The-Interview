using UnityEngine;

public class Shop : MonoBehaviour
{
    public Sprite shop2;

    public GameObject boy;
    private float _distance;

    public Sprite shop1;

    private SpriteRenderer _spriteRenderer;

    public GameObject buy;
    public GameObject sell;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeShop();
    }



    private void ChangeShop()
    {
        _distance = Vector3.Distance(boy.transform.position, transform.position);

        Sprite theSprite = _spriteRenderer.sprite;

        if (_distance < 3 && theSprite == shop1)
        {
            _spriteRenderer.sprite = shop2;
            
            buy.SetActive(true);
            sell.SetActive(true);
            
        }
        else if (_distance > 3 && theSprite == shop2)
        {
            _spriteRenderer.sprite = shop1;
            
            buy.SetActive(false);
            sell.SetActive(false);
        }
    }
}