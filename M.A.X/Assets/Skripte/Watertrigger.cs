using UnityEngine;
using System.Collections;

public class Watertrigger : MonoBehaviour {

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
            //player.GetComponent<IgralecKontroler>().water = true;
            player.GetComponent<IgralecKontroler>().disabled = true;
            player.GetComponent<WaterController>().disabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //player.GetComponent<IgralecKontroler>().water = false;
            player.GetComponent<IgralecKontroler>().disabled = false;
            player.GetComponent<WaterController>().disabled = true;
        }
    }
}
