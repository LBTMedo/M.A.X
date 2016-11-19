using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    public int value = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameManager.DodajDenar(value);
            Destroy(gameObject);
        }
    }
}
