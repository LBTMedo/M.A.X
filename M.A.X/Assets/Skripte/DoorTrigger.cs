using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

    public bool entered;
    public bool requiresKey = false;
    public bool picked = false;
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
            if (!requiresKey)
                entered = true;
            else{
                if (picked)
                {
                    entered = true;
                }
                else
                {
                    Debug.Log("Key needed.");
                }                
             }
        }
    }
}
