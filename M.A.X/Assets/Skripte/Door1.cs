using UnityEngine;
using System.Collections;

public class Door1 : MonoBehaviour {

    Button1 button1;
    private bool pressed;
    public float distance = 100f;
    private int count = 0;

    public bool door1, door2, door3;

    GameObject b;
	// Use this for initialization
	void Start () {
        if (door1 == true)
            b = GameObject.Find("Button1");
        if (door2 == true)
            b = GameObject.Find("Button2");
        if (door3 == true)
            b = GameObject.Find("Button3");        
	}
	
	// Update is called once per frame
	void Update () {

        pressed = b.GetComponent<Button1>().pressed;

        if (pressed && count == 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * distance);
            count = 1;
        }
	}
}
