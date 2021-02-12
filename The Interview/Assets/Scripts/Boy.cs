using TMPro;
using UnityEngine;

public class Boy : MonoBehaviour
{
    private Animator _animator;

    private static readonly int Leftright = Animator.StringToHash("leftright");
    private static readonly int Updown = Animator.StringToHash("updown");


    private float _hor;
    private float _ver;
    public float speed = 3;
    private bool _firstTime;

    private Rigidbody2D _rigidbody;

    public GameObject[] outfitGameObjects;
    public GameObject[] equipGameObjects;

    public GameObject cashGameObject;
    public GameObject outfitNoGameObject;
    public GameObject controls;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.freezeRotation = true;

        SaveOutfitsFirstTime();
        SetCashAndOutfitNo();
        SetOutfitAndEquip();
    }


    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger(Leftright, (int) Input.GetAxisRaw("Horizontal"));
        _animator.SetInteger(Updown, (int) Input.GetAxisRaw("Vertical"));


        _hor = Input.GetAxis("Horizontal");
        _ver = Input.GetAxis("Vertical");

        HideControls();
    }


    private void FixedUpdate()
    {
        if ((!Input.GetKey(KeyCode.LeftArrow) || !Input.GetKey(KeyCode.RightArrow)) &&
            (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D)) &&
            (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S)) &&
            (!Input.GetKey(KeyCode.DownArrow) || !Input.GetKey(KeyCode.UpArrow)))
        {
            transform.position += new Vector3(_hor * speed, _ver * speed, 0) * Time.deltaTime;
        }
    }

    private void SaveOutfitsFirstTime()
    {
        const int first = 1;

        if (PlayerPrefs.GetInt("firstTime") != first)
        {
            Outfit[] outfits = new Outfit[5];
            for (int i = 0; i < 5; i++)
            {
                outfits[i] = new Outfit(i);
            }


            OutfitHelper.Save(outfits);

            PlayerPrefs.SetInt("firstTime", first);


            //cash
            PlayerPrefs.SetInt("cash", 311);

            //outfit no
            PlayerPrefs.SetInt("outfitNo", 1);

            PlayerPrefs.SetInt("buyPos", 0);

            PlayerPrefs.SetInt("sellPos", 1);

            //show controls
            _firstTime = true;
            controls.SetActive(true);
        }
    }


    private void SetCashAndOutfitNo()
    {
        cashGameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("cash").ToString();
        outfitNoGameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("outfitNo").ToString();
    }

    public void SetOutfitAndEquip()
    {
        SetOutfit(OutfitHelper.SelectedOutfitPos());
        SetEqip(OutfitHelper.SelectedOutfit());
    }


    // Here we would change the animations for the outfit and accessories
    // or show the accessories if they are hidden
    // 
    // e.g.
    // _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(
    // "Animations/Outfit1_Equip1_Equip4");

    private void SetOutfit(int i)
    {
        //outfit 0

        if (i == 0)
        {
            foreach (var outfit in outfitGameObjects)
            {
                outfit.SetActive(false);
            }
        }
        //others
        else
        {
            i--;
            for (int outfitPos = 0; outfitPos < outfitGameObjects.Length; outfitPos++)
            {
                if (outfitPos == i)
                {
                    outfitGameObjects[outfitPos].SetActive(true);
                }
                else
                {
                    outfitGameObjects[outfitPos].SetActive(false);
                }
            }
        }
    }

    private void SetEqip(Outfit outfit)
    {
        for (int equipPos = 0; equipPos < outfit.equips.Length; equipPos++)
        {
            if (outfit.equips[equipPos].isSelected)
            {
                equipGameObjects[equipPos].SetActive(true);
            }
            else
            {
                equipGameObjects[equipPos].SetActive(false);
            }
        }
    }

    private void HideControls()
    {
        if (!_firstTime) return;

        if (_hor != 0 || _ver != 0 || Input.GetKeyDown(KeyCode.E))
        {
            controls.SetActive(false);
        }
    }
}