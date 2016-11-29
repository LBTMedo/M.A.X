using UnityEngine;
using System.Collections;

public class MetekSpawn : MonoBehaviour {

    Rigidbody2D rb2d;
    public float speed = 100f;

    BSManager manager;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(-Vector2.right.x * speed, 0.5f));

        manager = FindObjectOfType<BSManager>();
    }

    public void Spawn()
    {
        manager.SpawnEnemy(new Vector3(transform.position.x, transform.position.y + 1f), transform.rotation);
        Destroy(gameObject);
    }
}
