﻿using UnityEngine;
using System.Collections;

public class EndlessPC : MonoBehaviour {

    Igralec player;

    [SerializeField]
    private float moveSpeed = 1f;
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

        InvokeRepeating("PovecajHitrost", 10f, 10f);
    }

    void PovecajHitrost()
    {
        moveSpeed += 1;
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
        rbd.velocity = new Vector2(10f, rbd.velocity.y);
    }

    void FixedUpdate()
    {
        //set player velocity (x axis)        

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

    bool Grounded() //returns true if player is on the "Ground" layer
    {
        grounded = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.3f, Ground);
        return grounded;
        //return Physics2D.OverlapCircle(groundCheck.position, 0.1f, Ground); 
    }
}
