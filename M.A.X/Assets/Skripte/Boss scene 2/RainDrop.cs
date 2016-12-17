using UnityEngine;
using System.Collections;

public class RainDrop : MonoBehaviour {

	/*void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag != "Brick")
        Destroy(this.gameObject);
    }*/

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag != "Brick")
        {
            Destroy(this.gameObject);
        }
    }
}
