using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public float width;
    public float height;
    public Sprite destroyedObject;
    SpriteRenderer current;
    Vector3 scale;
    Transform size;
    BoxCollider2D collider;
    Rigidbody2D body;

    void Start()
    {
        current = GetComponent<SpriteRenderer>();
        size = GetComponent<Transform>();
        collider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        scale = new Vector3(width, height, 1f);
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != "Brick")
        {
            current.sprite = destroyedObject;
            size.transform.localScale = scale;
            collider.enabled = false;
            body.gravityScale = 0;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
