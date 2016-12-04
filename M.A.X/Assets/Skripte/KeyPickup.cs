using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {

    public bool picked;
    public GameObject doortrigger;
	// Use this for initialization
	void Start () {
        picked = false;
    }

    void Update()
    {
        
    }
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            picked = true;
            doortrigger.GetComponent<DoorTrigger>().picked = true;
            Destroy(gameObject);
        }
    }
}
