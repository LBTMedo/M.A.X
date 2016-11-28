using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour
{

    public bool entered;
    public float distance = 15f;
    private int count = 0;

    // Use this for initialization
    void Start()
    {
        entered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (entered && count == 0)
        {
            transform.Translate(-Vector2.up * Time.deltaTime * distance);
            count++;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            entered = true;
        }
    }
}