using UnityEngine;
using System.Collections;

public class Artefact_pickup : MonoBehaviour {

    private GameObject player;
    private Artefacts list;
    public int index;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Max");
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            list = player.GetComponent<Artefacts>();
            list.artefacts[index] = true;
            Debug.Log("Added artefact to list");
            Destroy(gameObject);
        }
    }
}
