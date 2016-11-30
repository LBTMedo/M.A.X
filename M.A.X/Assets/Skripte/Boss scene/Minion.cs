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

    Vector3 smer;

    Rigidbody2D rb2d;

    private float damage;

    Igralec igralec;

    private void Start()
    {
        zacetnaZivljenja = Random.Range(1, 2) * 100;
        trenutnaZivljenja = zacetnaZivljenja;

        highspeed = Random.Range(1.5f, 2) * speed;
        currentSpeed = speed;

        damage = Random.Range(20, 40);

        rb2d = GetComponent<Rigidbody2D>();

        smer = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);

        igralec = FindObjectOfType<Igralec>();
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
        smer = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
        rb2d.velocity = new Vector3((-Vector3.right.normalized.x * currentSpeed * Time.fixedDeltaTime), rb2d.velocity.y);
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
        if(Vector2.Distance(igralec.transform.position, transform.position ) <= 2f)
        {
            igralec.PrejmiSkodo(40);
            Debug.Log("Skoda");
        }
        Destroy(gameObject);
    }

    void Move()
    {
        Vector3 dir;

    }

    void PrejmiSkodo(float dmg)
    {
        trenutnaZivljenja -= zacetnaZivljenja;
    }

}
