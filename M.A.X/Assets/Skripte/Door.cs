using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject trigger;
    private bool entered;
    public float distance = 20f;
    public int MoveTimes = 1;
    private int count = 0;
	
    // Use this for initialization
	void Start () {
        entered = false;        
	}
	
	// Update is called once per frame
	void Update () {

        entered = trigger.GetComponent<DoorTrigger>().entered;
        
	    if (entered && count < MoveTimes)
        {
            transform.Translate(Vector3.up * distance);
            count++; 
        }
	}
}
