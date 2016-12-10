using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Boss : MonoBehaviour {

    public GameObject minionMetek;
    public GameObject spellMetek;

    Igralec player;

    public Transform spawn;
    public Transform strelPoint;
    Rigidbody2D metek;

    public float armour = 10f;

    public Transform pogledZid;
    Rigidbody2D rb2d;

    public float timer = 3f;
    public float akcija = 3f;

    [SerializeField]
    private float speed = 100f;
    [SerializeField]
    private float hitrostMetka = 100f;

    [SerializeField]
    private float health = 100;

    public Slider healthBar;

    public event System.Action ObSmrti;

    public int steviloMinionov = 10;
    private int trenutniMinion;

    [SerializeField]
    private bool sedi = true;
    [SerializeField]
    private bool sePremika = false;
    [SerializeField]
    private bool levo;

    public Igralec igralec;
    public IgralecKontroler kontroler;
    public Igralec_borba borba;

    private Animator anim;
    bool notDead = true;

    private void Start()
    {
        //igralec = FindObjectOfType<Igralec>();
        //kontroler = FindObjectOfType<IgralecKontroler>();
        //borba = FindObjectOfType<Igralec_borba>();

        SpawnMinion();
        trenutniMinion = 0;

        player = FindObjectOfType<Igralec>();

        levo = true;
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();


        healthBar.value = Mathf.RoundToInt(health);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && trenutniMinion < steviloMinionov)
        {
            anim.SetBool("shoot", true);
            timer = 3f;
            SpawnMinion();
        }
        else
        {
            anim.SetBool("shoot", false);
        }

        akcija -= Time.deltaTime;
        if (akcija <= 0 && !sedi)
        {
            anim.SetBool("shoot", true);
            akcija = 3f;
            Streljaj();
        }
        else
        {
            anim.SetBool("shoot", false);
        }

        if (trenutniMinion == steviloMinionov)
        {
            sedi = !sedi;
            sePremika = !sePremika;
            trenutniMinion++;
        }

        if (health <= 0)
        {
            Smrt();
        }
    }

    void Smrt()
    {
        if (ObSmrti != null)
        {
            ObSmrti();
        }

        igralec.disabled = false;
        //kontroler.disabled = false;
        borba.disabled = false;
        Time.timeScale = 1f;

        //Animacija BOOM


        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if(!sedi && sePremika)
        {
            anim.SetFloat("speed", 1f);
            Raycasting();
            Move();
        }
        else
        {
            anim.SetFloat("speed", 0f);
        }
    }

    public void SpawnMinion()
    {
        //anim.SetBool("shoot", true);
        metek = Instantiate(minionMetek, spawn.position, spawn.rotation) as Rigidbody2D;
        trenutniMinion++;
        //anim.SetBool("shoot", false);
    }

    void Raycasting()
    {
        Debug.DrawLine(transform.position, pogledZid.position, Color.red);
    }

    void Move()
    {
        float playerX = player.transform.position.x;
        float bossX = transform.position.x;

        if(playerX > bossX && levo)
        {
            //Invoke("Obrni", 0.5f);
            Obrni();
        }

        if(playerX < bossX && !levo)
        {
            //Invoke("Obrni", 0.5f);
            Obrni();
        }

        Vector3 dir;

        if (levo)
        {
            dir = -Vector2.right;
        }
        else
        {
            dir = Vector2.right;
        }
        rb2d.velocity = new Vector3(dir.x * speed * Time.fixedDeltaTime, rb2d.velocity.y);

    }

    void Obrni()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        levo = !levo;
    }

    void Streljaj()
    {
        //anim.SetBool("shoot", true);
        Rigidbody2D spell = Instantiate(spellMetek, strelPoint.position, strelPoint.rotation) as Rigidbody2D;

        //spell.velocity = transform.right * hitrostMetka;
        //anim.SetBool("shoot", false);
    }

    void PrejmiSkodo(float ammount)
    {
        ammount /= armour;

        if (!sedi && notDead)
        {
            health -= ammount;
            healthBar.value = Mathf.RoundToInt(health);
            if(health <= 10)
            {
                armour = 0.1f;
                SlowMotion();
                notDead = false;
            }
        }
    }

    void Damage()
    {
        Smrt();
        healthBar.gameObject.SetActive(false);
    }

    void SlowMotion()
    {
        // igralec.disabled = true;
        //kontroler.disabled = true;
        //borba.disabled = true;
        Time.timeScale = 0.2f;

        Invoke("Napad", 0.4f);
    }

    void Napad()
    {
        //kontroler.SlowMotionAttack();
        Damage();
    }
}
