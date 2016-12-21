using UnityEngine;
using System.Collections;

public class CPTrigger : MonoBehaviour {

    private int count;
    private Checkpoints cp;
	// Use this for initialization
	void Start () {
        count = 0;
        cp = GameObject.Find("Checkpoints").GetComponent<Checkpoints>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && count == 0)
        {
            cp.currentCheckpoint = transform;
            count++;
        }
    }


}
