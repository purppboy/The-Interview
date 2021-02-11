using UnityEngine;

public class Boy : MonoBehaviour
{
    private Animator _animator;

    private static readonly int Leftright = Animator.StringToHash("leftright");
    private static readonly int Updown = Animator.StringToHash("updown");

    private float _hor;
    private float _ver;
    public float speed = 3;
    private Rigidbody2D _rigidbody;

    public GameObject[] outfitGameObjects;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.freezeRotation = true;

        SaveOutfitsFirst();
        SetOutfit();
    }


    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger(Leftright, (int) Input.GetAxisRaw("Horizontal"));
        _animator.SetInteger(Updown, (int) Input.GetAxisRaw("Vertical"));


        _hor = Input.GetAxis("Horizontal");
        _ver = Input.GetAxis("Vertical");
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

    private void SaveOutfitsFirst()
    {
        const int first = 1;

        if (PlayerPrefs.GetInt("firstTime") != first)
        {
            Outfit[] outfits = new Outfit[4];
            for (int i = 0; i < 4; i++)
            {
                outfits[i] = new Outfit(i);
            }

            OutfitHelper.Save(outfits);
            PlayerPrefs.SetInt("firstTime", first);

            //cash
            PlayerPrefs.SetInt("cash", 208);

            //outfit no
            PlayerPrefs.SetInt("outfitNo", 1);
        }
    }

    public void SetOutfit()
    {
        int i = OutfitHelper.SelectedOutfitPos();

        //outfit 0

        if (i == 0)
        {
            foreach (var iOutfit in outfitGameObjects)
            {
                iOutfit.SetActive(false);
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
}