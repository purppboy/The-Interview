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


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.freezeRotation = true;
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
}