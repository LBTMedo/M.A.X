using UnityEngine;
using System.Collections;

public class PleagueBall : MonoBehaviour {

    int collisions = 0;
    public float damage = 20f;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("Tla") || coll.gameObject.layer == LayerMask.NameToLayer("Unwalkable"))
        {
            if(coll.gameObject.tag == "Odprtina")
            {
                return;
            }
            Destroy(gameObject);
        }
        if(coll.gameObject.layer == LayerMask.NameToLayer("Igralec"))
        {
            coll.gameObject.GetComponent<Igralec>().PrejmiSkodo(damage);
            Destroy(gameObject);
        }


    }

}
