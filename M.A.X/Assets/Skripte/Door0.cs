using UnityEngine;
using System.Collections;

public class Door0 : MonoBehaviour {

    private bool entered;
    private int count = 0;
    public float distance = 100f;

    GameObject trigger;
	// Use this for initialization
	void Start () {
        trigger = GameObject.Find("Door trigger");
	}
	
	// Update is called once per frame
	void Update () {
        entered = trigger.GetComponent<DoorTrigger>().entered;

        if (entered && count == 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * distance);
            count = 1;
        }
    }
}
