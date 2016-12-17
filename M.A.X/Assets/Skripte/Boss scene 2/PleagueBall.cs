using UnityEngine;
using System.Collections;

public class PleagueBall : MonoBehaviour {

    int collisions = 0;

	void OnTriggerEnter2D(Collider2D coll)
    {
        collisions += 1;
        if (collisions == 2 && coll.tag == "Player")
        {
            Destroy(this.gameObject);
        }
        else if(collisions == 3)
        {
            Destroy(this.gameObject);
        }
    }

}
