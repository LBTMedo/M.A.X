using UnityEngine;
using System.Collections;

public class Sovraznik : MonoBehaviour
{

    public AudioClip zvokPrejmiSkodo;
    public AudioClip zvokUmri;
    public AudioClip zvokStreljaj;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public enum State { idle, attacking };
    public enum Vrsta { navadni, leteci };

    public float zacetnaZivljenja;
    public float trenutnaZivljenja;
    public float rayLength = 15;
    public float verjetnostObrata = 10f;
    public float pogled = 10f;
    float dolzinaY;
    float pozicijaX;
    public float hitrostPikiranja = 1000f;

    bool pozicijaDesno = true;
    bool pikira = false;

  //  public GameObject grafika;

    public Transform pogledKonec;
    public Transform pogledTla;

    private Sovraznik_Borba sistemZaBorbo;

    public State state;
    public Vrsta vrsta;

    public bool left = false;
    [SerializeField]
    private bool sePremika = false;
    [SerializeField]
    private bool spotted = false;
    [SerializeField]
    private bool tla = false;
    [SerializeField]
    private bool zeNapada = false;
    [SerializeField]
    private float speed = 10;
    private float casPredBrisanjem = 3f;
    [SerializeField]
    int stKovancev;

    Vector3 levo;
    Vector3 desno;
    Vector3 startPozicija;

    Rigidbody2D rb2d;
    Igralec player;
    public Rigidbody2D kovanecPrefab;

    Coroutine streljanje;

    Vector3 direction;

    protected bool mrtev = false;

    public event System.Action ObSmrti;

    void Start()
    {
        source = GetComponent<AudioSource>();
        stKovancev = Random.Range(1, 4);
        trenutnaZivljenja = zacetnaZivljenja;
        startPozicija = transform.position;

        rb2d = GetComponent<Rigidbody2D>();
        state = State.idle;

        levo = new Vector3(startPozicija.x - 5, startPozicija.y, startPozicija.z);
        desno = new Vector3(startPozicija.x + 5, startPozicija.y, startPozicija.z);

        player = FindObjectOfType<Igralec>();

        InvokeRepeating("NakljucniObrat", 0f, 1f);

        sistemZaBorbo = GetComponent<Sovraznik_Borba>();

        if(vrsta == Vrsta.leteci)
        {
           // grafika = null;
        }
       

        dolzinaY = Vector3.Distance(transform.position, pogledKonec.position);
        pozicijaX = pogledKonec.position.x;
    }

    void FixedUpdate()
    {
        if (!spotted && !mrtev)
        {
            Move();
            ChangeDirection();
        }
        else if (spotted && !zeNapada)
        {
            Attack();
            zeNapada = true;
        }
        if (pikira)
        {
            float step = hitrostPikiranja * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, direction, step);
        }

    }

    void Attack()
    {
        if (vrsta == Vrsta.navadni)
        {
            InvokeRepeating("Streljaj", 0f, 0.5f);
        }
        else if(vrsta == Vrsta.leteci)
        {
            Pikiraj();
        }
    }

    void Pikiraj()
    {
        pikira = true;
        Debug.Log("Pikiranje");
    }

    void Streljaj()
    {
        source.PlayOneShot(zvokStreljaj, 1F);
        sistemZaBorbo.Streljanje();
    }

    void Update()
    {
        Raycasting();
        if (sePremika)
        {
            //grafika.GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
        {
           // grafika.GetComponent<Animator>().SetBool("isMoving", false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PrejmiSkodo(50);
        }
    }

    void Raycasting()
    {
        if (vrsta == Vrsta.navadni)
        {
            Debug.DrawLine(transform.position, pogledKonec.position, Color.blue);
            Debug.DrawLine(new Vector3(transform.position.x, (float)(transform.position.y + 0.2), transform.position.z), new Vector3(pogledTla.position.x, (float)(pogledTla.position.y + 0.2), pogledTla.position.z), Color.blue);

            if (Physics2D.Linecast(transform.position, pogledKonec.position, 1 << LayerMask.NameToLayer("Igralec")))
            {
                state = State.attacking;
                sePremika = false;
                spotted = true;
                rb2d.velocity = Vector3.zero;
            }

            if (Physics2D.Linecast(transform.position, pogledTla.position, 1 << LayerMask.NameToLayer("Tla")))
            {
                ChangeDirectionSimple();
                tla = true;
            }
        }
        else if(vrsta == Vrsta.leteci)
        {
            if (pozicijaDesno)
            {
                PozicijaDesno();
            }
            else
            {
                PozicijaLevo();
            }

            if(pozicijaX >= pogledKonec.position.x + pogled || pozicijaX <= pogledKonec.position.x - pogled)
            {
                FlipRayCast();
            }
            
            Debug.DrawLine(transform.position, new Vector3(pozicijaX, dolzinaY), Color.red);

            if (Physics2D.Linecast(transform.position, new Vector3(pozicijaX, dolzinaY), 1 << LayerMask.NameToLayer("Igralec")))
            {
                state = State.attacking;
                sePremika = false;
                spotted = true;
                rb2d.velocity = Vector3.zero;
                //direction = new Vector3(pozicijaX, dolzinaY + 1f);
                direction = player.transform.position;
            }

            if (Physics2D.Linecast(transform.position, pogledTla.position, 1 << LayerMask.NameToLayer("Tla")))
            {
                ChangeDirectionSimple();
                tla = true;
            }
        }
    }

    void PozicijaLevo()
    {
        pozicijaX -= 0.1f;
    }


    void PozicijaDesno()
    {
        pozicijaX += 0.1f;
    }

    void FlipRayCast()
    {
        pozicijaDesno = !pozicijaDesno;
    }

    void ChangeDirectionSimple()
    {
        FlipPlayer();
        left = !left;
    }

    void ChangeDirection()
    {
        if (left)
        {
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
        sePremika = true;

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
        source.PlayOneShot(zvokPrejmiSkodo, 1F);
        trenutnaZivljenja -= skoda;
        if (trenutnaZivljenja <= 0 && !mrtev)
        {
            Smrt();
        }
    }

    void NakljucniObrat()
    {
        int st1 = Mathf.RoundToInt(Random.Range(0, (1000 / verjetnostObrata)));
        int st2 = Mathf.RoundToInt(Random.Range(0, (1000 / verjetnostObrata)));

        if(st1 == st2)
        {
            ChangeDirectionSimple();
            return;
        }
        else
        {
            return;
        }
    }


    public virtual void Smrt()
    {
        source.PlayOneShot(zvokUmri, 1F);
        mrtev = true;
        if (ObSmrti != null)
        {
            ObSmrti();
        }
        rb2d.velocity = Vector3.zero;

        for (int i = 0; i < stKovancev; i++)
        {
            Rigidbody2D kovanec = Instantiate(kovanecPrefab, transform.position, transform.rotation) as Rigidbody2D;
            kovanec.AddForce(new Vector2(Random.Range(1, 4), Random.Range(1, 4)) * Random.Range(10,40));
        }

        //StopCoroutine(streljanje);
        sePremika = false;

        transform.Rotate(new Vector3(0, 0, 90));
        Invoke("DestroyGO", casPredBrisanjem);
    }

    void DestroyGO()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (vrsta == Vrsta.leteci)
        {
            if (other.tag == "Player")
            {
                other.gameObject.SendMessage("PrejmiSkodo", 50f);
                for (int i = 0; i < stKovancev; i++)
                {
                    Rigidbody2D kovanec = Instantiate(kovanecPrefab, transform.position, transform.rotation) as Rigidbody2D;
                    kovanec.AddForce(new Vector2(Random.Range(1, 4), Random.Range(1, 4)) * Random.Range(10, 40));
                }
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}