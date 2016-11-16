using UnityEngine;
using System.Collections;

public class Enlarge : MonoBehaviour {

    Igralec igralec;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            igralec = other.gameObject.GetComponent<Igralec>();
            igralec.SendMessage("Enlarge");
            Destroy(gameObject);
        }
    }
}
