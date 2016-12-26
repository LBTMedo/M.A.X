using UnityEngine;
using System.Collections;

public class RainDrop : MonoBehaviour {

    public float damage = 2f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.layer == LayerMask.NameToLayer("Tla") || coll.gameObject.layer == LayerMask.NameToLayer("Unwalkable"))
        {
            Destroy(gameObject);
        }
        if (coll.gameObject.layer == LayerMask.NameToLayer("Igralec"))
        {
            coll.gameObject.GetComponent<Igralec>().PrejmiSkodo(damage);
        }
    }
}
