using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

    public int value = 1;
    //  public AudioClip zvokCoin;
    //private AudioSource source;

    GenerateLevel generator;

    void Start()
    {
        // source = GetComponent<AudioSource>();
        generator = FindObjectOfType<GenerateLevel>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player")
        {
            //source.PlayOneShot(zvokCoin, 1F);
            GameManager.DodajDenar(value);
            generator.AddScore(value);
            Destroy(transform.parent.gameObject);
        }
    }
}
