using UnityEngine;
using System.Collections;

public class Activate_Deactivate : MonoBehaviour {
    public bool activate;
    public GameObject trap;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (activate)
            {
                trap.GetComponent<Pendulum>().deactivated = false;
            }
            if (!activate)
            {
                trap.GetComponent<Pendulum>().deactivated = true;
            }
        }
    }
}
