using UnityEngine;
using System.Collections;

public class RocnoOrozje : MonoBehaviour {

    public float damage = 20f;
    public float cena;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Sovraznik")
        {
            coll.gameObject.SendMessage("PrejmiSkodo", damage);
        }
    }
}
