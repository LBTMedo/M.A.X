using UnityEngine;
using System.Collections;

public class Minion : MonoBehaviour {

    public float speed = 10f;
    private float highspeed;
    [SerializeField]
    private float currentSpeed;

    public float zacetnaZivljenja;
    public float trenutnaZivljenja;

    public float pogledSprint = 10f;
    public float pogledBoom = 1f;

    public Transform smer;

    Rigidbody2D rb2d;

    private float damage;

    private void Start()
    {
        zacetnaZivljenja = Random.Range(1, 2) * 100;
        trenutnaZivljenja = zacetnaZivljenja;

        highspeed = Random.Range(1.5f, 2) * speed;
        currentSpeed = speed;

        damage = Random.Range(20, 40);

        rb2d = GetComponent<Rigidbody2D>();        
    }

    private void Update()
    {
        if(trenutnaZivljenja <= 0)
        {
            Smrt();
        }
    }

    void Smrt()
    {
        Invoke("DestroyGO", 0.2f);
    }

    void DestroyGO()
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        Raycasting();
        Move();
    }

    void Raycasting()
    {
        Debug.DrawLine(transform.position, new Vector3(transform.position.x - pogledSprint, transform.position.y), Color.red);
        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y + 0.5f), new Vector3(transform.position.x - pogledBoom, transform.position.y + 0.5f), Color.red);

        if (Physics2D.Linecast(transform.position, new Vector3(transform.position.x - pogledSprint, transform.position.y), 1 << LayerMask.NameToLayer("Igralec")))
        {
            currentSpeed = highspeed;
        }

        if (Physics2D.Linecast(transform.position, new Vector3(transform.position.x - pogledBoom, transform.position.y + 0.5f), 1 << LayerMask.NameToLayer("Igralec")) || Physics2D.Linecast(transform.position, new Vector3(transform.position.x - pogledBoom, transform.position.y + 0.5f), 1 << LayerMask.NameToLayer("Tla")))
        {
            Explode();
        }

    }

    void Explode()
    {
        Debug.Log("Explode!");
    }

    void Move()
    {
        Vector3 dir = smer.position - transform.position;
        // transform.Translate(smer.position);

        //rb2d.AddForce(dir * speed * Time.fixedDeltaTime);
        rb2d.velocity = new Vector3(dir.normalized.x * (speed * Time.fixedDeltaTime), rb2d.velocity.y);
    }

    void PrejmiSkodo(float dmg)
    {
        trenutnaZivljenja -= zacetnaZivljenja;
    }

}
