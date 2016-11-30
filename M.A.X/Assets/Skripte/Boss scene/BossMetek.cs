using UnityEngine;
using System.Collections;

public class BossMetek : MonoBehaviour {

    Igralec igralec;

    Rigidbody2D rb2d;

    public float speed = 100f;
    public float damage = 20f;

    Vector3 dir;

    // Use this for initialization
    void Start ()
    {
        igralec = FindObjectOfType<Igralec>();
        rb2d = GetComponent<Rigidbody2D>();

        dir = igralec.transform.position - transform.position;

        
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(new Vector2(dir.normalized.x, dir.normalized.y) * speed * Time.fixedDeltaTime * 100);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("PrejmiSkodo", damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
