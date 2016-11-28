using UnityEngine;
using System.Collections;

public class Button4 : MonoBehaviour {

    public bool pressed;
    public float distance = 15f;
    private int count = 0;

    GameObject largeElevator;
    ElevatorMovement movement;

    // Use this for initialization
    void Start()
    {
        largeElevator = GameObject.Find("DisabledElevator");
        movement = largeElevator.GetComponent<ElevatorMovement>();
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && count == 0)
        {
            transform.Translate(-Vector2.up * Time.deltaTime * distance);
            movement.move = true;
            count++;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        pressed = true;
    }
}
