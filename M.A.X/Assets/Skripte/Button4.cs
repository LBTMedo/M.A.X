using UnityEngine;
using System.Collections;

public class Button4 : MonoBehaviour {

    public bool pressed;

    public GameObject largeElevator;

    // Use this for initialization
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pressed = true;
            largeElevator.GetComponent<ElevatorMovement>().move = true;
        }
    }
}
