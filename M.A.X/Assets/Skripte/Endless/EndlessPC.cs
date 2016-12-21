using UnityEngine;
using System.Collections;

public class EndlessPC : MonoBehaviour {

    Igralec player;

    [SerializeField]
    private float moveSpeed = 6f;
    private float jumpHeight = 20f;
    private float sprintSpeed = 30f;
    private float originalMoveSpeed;
    public float airControll = 1; //air velocity multiplier

    public AudioClip zvok;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public LayerMask Ground;
    public Transform groundCheck;

    public bool grounded;

    private bool facingRight;
    private bool jump;

    public Vector3 currentScale;

    public bool disabled = false;

    Boss boss = null;
    Igralec_borba borba = null;

    public bool zacetek = false;

    GenerateLevel generator;


    public bool desno
    {
        get
        {
            return facingRight;
        }
        private set
        {
            facingRight = value;
        }
    }

    public float hitrostPremikanje
    {
        set { moveSpeed = value; }
        get { return moveSpeed; }
    }

    private int Jumps; //num of current jumps
    public int originalJumps = 2; //the original num of jumps

    private Rigidbody2D rbd;

    public float stevec;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        player = GetComponent<Igralec>();
        rbd = GetComponent<Rigidbody2D>();

        originalMoveSpeed = player.movementSpeed;
        jumpHeight = player.jumpHeight;
        sprintSpeed = player.sprintSpeed;

        moveSpeed = originalMoveSpeed;

        facingRight = true;
        jump = false;
        Jumps = originalJumps;

        currentScale = transform.localScale;

        if (disabled)
        {
            boss = FindObjectOfType<Boss>();
            borba = FindObjectOfType<Igralec_borba>();
        }

        stevec = 15f;

        generator = FindObjectOfType<GenerateLevel>();
    }

    void Update()
    {
        if (!disabled)
        {
            if (Input.GetKeyDown(KeyCode.Space) && Jumps != 0)
            {
                Debug.Log("Space");
                jump = true;
            }
        }
        if (zacetek)
        {
            rbd.velocity = new Vector2(moveSpeed, rbd.velocity.y);

            stevec -= Time.deltaTime;
            if (stevec <= 0f)
            {
                stevec = 30f;
                moveSpeed += 1f;
            }
        }
    }

    void FixedUpdate()
    {
        //set player velocity (x axis)        

        if (Grounded())
        {
            Jumps = originalJumps;
        }

        if (jump && zacetek)
        {
            source.PlayOneShot(zvok, 1F);
            rbd.velocity = new Vector2(rbd.velocity.x, jumpHeight);
            jump = false;
            Jumps--;
        }
    }

    bool Grounded() //returns true if player is on the "Ground" layer
    {
        grounded = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.1f, Ground);
        //Debug.DrawRay(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - 0.3f), Color.red);
        return grounded;
        //return Physics2D.OverlapCircle(groundCheck.position, 0.1f, Ground); 
    }
}
