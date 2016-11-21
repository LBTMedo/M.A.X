using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    public int value = 1;
    public AudioClip zvokCoin;
    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            source.PlayOneShot(zvokCoin, 1F);
            GameManager.DodajDenar(value);
            Destroy(gameObject);
        }
    }
}
