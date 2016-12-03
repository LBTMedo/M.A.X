using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Player2Kotroler : MonoBehaviour {

    Igralec2 player;

    [SerializeField]
    private float moveSpeed = 20f;
    private float jumpHeight = 15f;
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
    }

    private int Jumps; //num of current jumps
    public int originalJumps = 2; //the original num of jumps

    private Rigidbody2D rbd;

    // Use this for initialization
    void Start()
    {

        source = GetComponent<AudioSource>();
        player = GetComponent<Igralec2>();
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
    }

    void Update()
    {
        if (!disabled)
        {
            if (Input.GetKeyDown(KeyCode.RightControl) && Jumps != 0)
            {
                Debug.Log("RightControl");
                jump = true;
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 moveDir;

        if (!disabled)
        {
            if (Input.GetKey(KeyCode.RightShift) && Grounded())
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = originalMoveSpeed;
            }

            if (Input.GetKey(KeyCode.Keypad4))
            {
                Debug.Log("keyPad4");
                moveDir = new Vector2(-moveSpeed, rbd.velocity.y);
                facingRight = false;
            }
            else if (Input.GetKey(KeyCode.Keypad6))
            {
                Debug.Log("keyPad6");
                moveDir = new Vector2(moveSpeed, rbd.velocity.y);
                facingRight = true;
            }
            else
            {
                if (Grounded())
                {
                    moveDir = new Vector2(0, 0);
                }
                else
                {
                    moveDir = new Vector2(0, rbd.velocity.y);
                }
            }



            if (!Grounded())
            {
                Debug.Log(airControll);
                moveDir.x = airControll * moveDir.x;
            }

            flip();

            rbd.velocity = moveDir; //set player velocity (x axis)        

            if (Grounded())
            {
                Jumps = originalJumps;
            }

            if (jump)
            {
                source.PlayOneShot(zvok, 1F);
                rbd.velocity = new Vector2(rbd.velocity.x, jumpHeight);
                jump = false;
                Jumps--;
            }
        }
    }

    bool Grounded() //returns true if player is on the "Ground" layer
    {
        grounded = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.3f, Ground);
        return grounded;
        //return Physics2D.OverlapCircle(groundCheck.position, 0.1f, Ground); 
    }

    void flip() //function to flip player left or right
    {
        if (facingRight)
        {
            transform.localScale = new Vector3(currentScale.x, currentScale.y, 1); //turn right ----> to spremni pol v 1.5, 1.5, 1
        }
        else if (!facingRight)
        {
            transform.localScale = new Vector3(-currentScale.x, currentScale.y, 1); //turn left -------> to spremni pol v obratno
        }
    }

    public void SlowMotionAttack()
    {
        if (disabled)
        {
            if (boss.gameObject.transform.position.x < transform.position.x && facingRight)
            {
                flip();
            }
            if (boss.gameObject.transform.position.x > transform.position.x && !facingRight)
            {
                flip();
            }
            borba.Streljaj();
        }
    }
}
