using UnityEngine;
using System.Collections;

public class Button1 : MonoBehaviour {

    public bool pressed;
    public float distance = 15f;
    private int count = 0;

    // Use this for initialization
    void Start () {
        pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (pressed && count == 0)
        {
            transform.Translate(-Vector2.up * Time.deltaTime * distance);
            count++;
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        pressed = true;
    }
}
