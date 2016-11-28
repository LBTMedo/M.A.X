using UnityEngine;
using System.Collections;

public class ButtonDoor : MonoBehaviour {

    private bool entered = false;
    public GameObject trigger;

    private int count = 0;
    public int movetimes = 1;
    public float distance = 2f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        entered = trigger.GetComponent<ButtonTrigger>().entered;

        if (entered && count < movetimes)
        {
            transform.Translate(Vector3.up * distance);
            count++;
        }
	
	}
}
