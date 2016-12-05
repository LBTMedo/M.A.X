using UnityEngine;
using System.Collections;

public class PPpickup : MonoBehaviour {

    private GameObject player;
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
            player.GetComponent<IgralecKontroler>().powerup = true;
            Destroy(gameObject);
        }
    }
}
