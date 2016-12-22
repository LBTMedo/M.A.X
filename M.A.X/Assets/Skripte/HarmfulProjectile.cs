using UnityEngine;
using System.Collections;

public class HarmfulProjectile : MonoBehaviour {

    public float damage;
    public float lifeTime;

    void Start()
    {
        Invoke("DestroyGo", lifeTime);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.SendMessage("PrejmiSkodo", damage);
            Destroy(gameObject);
        }
    }

    void DestroyGo()
    {
        Destroy(gameObject);
    }
}
