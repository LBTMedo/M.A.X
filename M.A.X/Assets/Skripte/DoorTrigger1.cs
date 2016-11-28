using UnityEngine;
using System.Collections;

public class DoorTrigger1 : MonoBehaviour {

    public bool entered;
	// Use this for initialization
	void Start () {
        entered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            entered = true;
        }
    }
}
