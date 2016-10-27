using UnityEngine;
using System.Collections;

public class Sovraznik : MonoBehaviour {

    public enum State { idle, attacking };

    public float zacetnaZivljenja;
    public float trenutnaZivljenja;
    public float rayLength = 15;

    public Transform pogledKonec;
    public Transform pogledTla;

    public State state;

    [SerializeField]
    private bool left = false;
    [SerializeField]
    private bool spotted = false;
    [SerializeField]
    private bool tla = false;
    [SerializeField]
    private bool zeNapada = false;
    [SerializeField]
    private float speed = 10;

    Vector3 levo;
    Vector3 desno;
    Vector3 startPozicija;

    Rigidbody2D rb2d;
    Igralec player;

    protected bool mrtev = false;

    public event System.Action ObSmrti;

    void Start()
    {
        trenutnaZivljenja = zacetnaZivljenja;
        startPozicija = transform.position;

        rb2d = GetComponent<Rigidbody2D>();
        state = State.idle;

        levo = new Vector3(startPozicija.x - 5, startPozicija.y, startPozicija.z);
        desno = new Vector3(startPozicija.x + 5, startPozicija.y, startPozicija.z);

        player = FindObjectOfType<Igralec>();

    }

    void FixedUpdate()
    {
        if(!spotted)
        {
            Move();
            ChangeDirection();
        }
        else if(spotted && !zeNapada)
        {
            InvokeRepeating("Attack", 0.5f, 1f);
            zeNapada = true;
        }
        
    }

    void Attack()
    {
        player.PrejmiSkodo(20);
    }

    void Update()
    {
        Raycasting();
    }

    void Raycasting()
    {
        Debug.DrawLine(transform.position, pogledKonec.position, Color.blue);
        Debug.DrawLine(new Vector3(transform.position.x, (float)(transform.position.y + 0.2), transform.position.z), new Vector3(pogledTla.position.x, (float)(pogledTla.position.y + 0.2), pogledTla.position.z), Color.blue);

        if (Physics2D.Linecast(transform.position, pogledKonec.position, 1 << LayerMask.NameToLayer("Igralec")))
        {
            state = State.attacking;
            spotted = true;
            rb2d.velocity = Vector3.zero;
        }

        if (Physics2D.Linecast(transform.position, pogledTla.position, 1 << LayerMask.NameToLayer("Tla")))
        {
            ChangeDirectionSimple();
            tla = true;
        }

    }

    void ChangeDirectionSimple()
    {
        FlipPlayer();
        left = !left;
    }

    void ChangeDirection()
    {
        if (left) {
            if (Vector3.Distance(transform.position, levo) <= 0.4f)
            {
                FlipPlayer();
                left = !left;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, desno) <= 0.4f)
            {
                FlipPlayer();
                left = !left;
            }
        }
    }

    void FlipPlayer()
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    void Move()
    {
        Vector3 dir;

        if (left)
        {
            dir = levo - transform.position;
        }
        else
        {
            dir = desno - transform.position;
        }

        rb2d.velocity = new Vector3(dir.normalized.x * (speed * Time.fixedDeltaTime), rb2d.velocity.y);
    }

    public void PrejmiSkodo(float skoda)
    {
        trenutnaZivljenja -= skoda;
        if (trenutnaZivljenja <= 0 && !mrtev)
        {
            Smrt();
        }
    }

    public virtual void Smrt()
    {
        mrtev = true;
        if (ObSmrti != null)
        {
            ObSmrti();
        }
        Destroy(gameObject);
    }
}
