using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCarton : MonoBehaviour {

    public float maxSpeed;
    public float jumpForce;
    public bool canDoubleJump;
    public float maxFallSpeed;
    private float move;
    private bool willDie = false;

    public bool isDead = false;

    private bool facingRight;
    public GameObject husk;
    public Transform huskSpawn;
    public Rigidbody2D rb2d;
    public GameObject body;
    public float facing;
    public Animator anim;
    public float animSpeed;

    public bool grounded;
    public Transform groundCheck;
    private Vector2 groundCap = new Vector2(2.5f, 0.35f);
    public LayerMask whatisGround;
    private AudioSource audioSource;

    private bool doubleJump = false;

    private GM gm;

    // Use this for initialization
    void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
        husk = Resources.Load("Player_Husk") as GameObject;
        huskSpawn = transform.GetChild(2).gameObject.transform;
        audioSource = transform.GetChild(0).GetComponent<AudioSource>();

        rb2d = GetComponent<Rigidbody2D>();
        body = transform.GetChild(0).GetChild(0).gameObject;
        anim = transform.GetChild(0).GetComponent<Animator>();
        groundCheck = transform.GetChild(1).transform;
    }


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapBox(groundCheck.position, groundCap, 0, whatisGround);

        if (rb2d.velocity.y < maxFallSpeed)
            willDie = true;

        if (grounded && willDie)
        {
            isDead = true;
            willDie = false;
        }

        if (grounded && canDoubleJump)
            doubleJump = false;

        if (!gm.holdPlayer)
        {
            move = Input.GetAxis("Horizontal");

            rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
        }

        if (Mathf.Abs(rb2d.velocity.x) < 0.5f)
            anim.SetBool("IsIdle", true);
        else
            anim.SetBool("IsIdle", false);

    }

    void Update()
    {

        if (!canDoubleJump)
        {
            doubleJump = true;
        }

        if ((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Open");
            audioSource.Play();
            GameObject shell = Instantiate(husk, huskSpawn.position, husk.transform.rotation);
            Rigidbody2D shellrb2d = shell.GetComponent<Rigidbody2D>();
            shellrb2d.velocity = new Vector2(Random.Range(-2, 2), 8);
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            if (!doubleJump && !grounded)
                doubleJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            isDead = true;
        }
    }
}
