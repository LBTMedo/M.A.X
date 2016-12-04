using UnityEngine;
using System.Collections;

public class KeyDoor : MonoBehaviour {

    public GameObject Trigger;
    private bool PickedUp;
    private int count = 0;
    [SerializeField]
    private float distance = 30f;
	// Use this for initialization
	void Start () {
        PickedUp = false;
	}
	
	// Update is called once per frame
	void Update () {
        PickedUp = Trigger.GetComponent<DoorTrigger>().entered;

        if (PickedUp && count == 0)
        {
            transform.Translate(Vector3.up * distance);
            count++;
        }
	}
}
