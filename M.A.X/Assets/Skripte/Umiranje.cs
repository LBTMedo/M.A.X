using UnityEngine;
using System.Collections;

public class Umiranje : MonoBehaviour {

    private Igralec player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<Igralec>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.SendMessage("PrejmiSkodo", 1000);
        }
        else
        {
            Destroy(coll.gameObject);
        }
    }
}
