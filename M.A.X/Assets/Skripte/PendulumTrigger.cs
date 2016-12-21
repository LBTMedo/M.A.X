using UnityEngine;
using System.Collections;

public class PendulumTrigger : MonoBehaviour {

    public GameObject pendulum;
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
            pendulum.GetComponent<Pendulum>().deactivated = false;
        }
    }
}
