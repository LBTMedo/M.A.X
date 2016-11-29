using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "spawn")
        {
            collision.GetComponent<MetekSpawn>().Spawn();
        }
    }
}
