using UnityEngine;
using System.Collections;

public class PleagueBall : MonoBehaviour {

    int collisions = 0;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("Tla") || coll.gameObject.layer == LayerMask.NameToLayer("Igralec") || coll.gameObject.layer == LayerMask.NameToLayer("Unwalkable"))
        {
            if(coll.gameObject.tag == "Odprtina")
            {
                return;
            }
            Destroy(gameObject);
        }


    }

}
