using UnityEngine;

public class TalkBoy : MonoBehaviour
{
    public Sprite talkRight;
    public Sprite talkLeft;

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = talkLeft;

        Vector3 position = transform.position;

        if (position.y > 3.91)
        {
            transform.position = new Vector3(position.x, 3.91f);
        }

        position = transform.position;

        if (position.x > 8.002759)
        {
            GetComponent<SpriteRenderer>().sprite = talkRight;

            transform.position = new Vector3(8.002759f, position.y);
        }
    }

    private void OnDisable()
    {
        transform.localPosition = new Vector3(1.05f, 1.95f);
    }
}