using UnityEngine;
using System.Collections;

public class RainDrop : MonoBehaviour {

	/*void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == LayerMask.NameToLayer("Tla"))
        {
            Destroy(this.gameObject);
        }
    }*/


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("Tla") || coll.gameObject.layer == LayerMask.NameToLayer("Unwalkable") || coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
