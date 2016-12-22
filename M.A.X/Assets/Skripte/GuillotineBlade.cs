using UnityEngine;
using System.Collections;

public class GuillotineBlade : MonoBehaviour {

    public float damage;

	void OnTriggerEnter2D(Collider2D coll)
    {
            if (coll.gameObject.tag == "Player")
            {
                coll.gameObject.SendMessage("PrejmiSkodo", damage);
            }
    }
}
