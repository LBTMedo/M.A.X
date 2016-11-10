using UnityEngine;
using System.Collections;

public class Metek : MonoBehaviour {

    public float damage = 20;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Sovraznik")
        {
            coll.gameObject.SendMessage("PrejmiSkodo", damage);
            Destroy(gameObject);
        }
    }
}
