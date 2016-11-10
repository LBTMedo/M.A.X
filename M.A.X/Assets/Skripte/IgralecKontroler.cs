using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class IgralecKontroler : MonoBehaviour {

    Igralec player;

    private float moveSpeed = 20f;
    private float jumpHeight = 15f;
    private float sprintSpeed = 30f;
    private float originalMoveSpeed;
    public float airControll = 1; //air velocity multiplier

    public LayerMask Ground;
    public Transform groundCheck;

    public bool grounded;

    private bool facingRight;
    private bool jump;

    private int Jumps; //num of current jumps
    public int originalJumps = 2; //the original num of jumps

    private Rigidbody2D rbd;

	// Use this for initialization
	void Start () {

        player = GetComponent<Igralec>();
        rbd = GetComponent<Rigidbody2D>();

        originalMoveSpeed = player.movementSpeed;
        jumpHeight = player.jumpHeight;
        sprintSpeed = player.sprintSpeed;

        moveSpeed = originalMoveSpeed;

        facingRight = true;
        jump = false;
        Jumps = originalJumps;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Jumps != 0)
        {
            Debug.Log("Space");
            jump = true;
        }
    }

    void FixedUpdate() {
        Vector2 moveDir;

        if (Input.GetKey(KeyCode.LeftShift) && Grounded())
        {
            moveSpeed = sprintSpeed;
        }
        else
        {
            moveSpeed = originalMoveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            moveDir = new Vector2(-moveSpeed, rbd.velocity.y);
            facingRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
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
            rbd.velocity = new Vector2(rbd.velocity.x, jumpHeight);
            jump = false;
            Jumps--;
        }
	}

    bool Grounded() //returns true if player is on the "Ground" layer
    {
        grounded = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.1f, Ground);
        return grounded;
        //return Physics2D.OverlapCircle(groundCheck.position, 0.1f, Ground); 
    }

    void flip() //function to flip player left or right
    {
        if (facingRight)
        {
            transform.localScale = new Vector3(2f, 2f, 1); //turn right ----> to spremni pol v 1.5, 1.5, 1
        }
        else if (!facingRight)
        {
            transform.localScale = new Vector3(-2f, 2f, 1); //turn left -------> to spremni pol v obratno
        }
    }
}
