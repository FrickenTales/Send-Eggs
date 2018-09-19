using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool walks;

    public float maxSpeed;
    public float jumpForce;
    public bool canDoubleJump;
    public float maxFallSpeed;
    public float move;
    private bool willDie = false;

    public bool isDead = false;

    private bool facingRight;
    public Rigidbody2D rb2d;
    public GameObject body;
    public float facing;
    public Animator anim;
    public float animSpeed;

    public bool grounded;
    public Transform groundCheck;
    private Vector2 groundCap = new Vector2 (0.8f,0.35f);
    //private float groundRadius = 0.15f;
    public LayerMask whatisGround;

    private bool doubleJump = false;

    private GM gm;

    // Use this for initialization
    void Awake ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        rb2d = GetComponent<Rigidbody2D>();
        body = transform.GetChild(0).GetChild(0).gameObject;
        anim = transform.GetChild(0).GetComponent<Animator>();
        groundCheck = transform.GetChild(1).transform;

        Flip();
	}
	

	void FixedUpdate ()
    {
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatisGround);
        //grounded = Physics2D.OverlapCapsule(groundCheck.position, groundCap, CapsuleDirection2D.Horizontal, 90, whatisGround);
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

        if (walks)
        {
            if (!gm.holdPlayer)
            {
                move = Input.GetAxis("Horizontal");

                rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
            }

            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();

            if (Mathf.Abs(rb2d.velocity.x) < 0.5f)
                anim.SetBool("IsIdle", true);
            else
                anim.SetBool("IsIdle", false);
        }
        else
        {
            if (!gm.holdPlayer)
            {
                if (rb2d.velocity.x == 0)
                {
                    move = 0;
                }

                move = Mathf.Lerp(move, Input.GetAxis("Horizontal"), Time.deltaTime * 2.3f);
            }

            rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

            if (grounded)
            {
                animSpeed = rb2d.velocity.x / 4.5f;
            }
            else
            {
                animSpeed = Mathf.Lerp(animSpeed, rb2d.velocity.x / 3, Time.deltaTime * .7f);
            }

            anim.SetFloat("RollSpeed", animSpeed);

        }
    }

    void Update()
    {

        if (!canDoubleJump)
        {
            doubleJump = true;
        }

        if((grounded || !doubleJump) && Input.GetButtonDown("Jump"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            if (!doubleJump && !grounded)
                doubleJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            isDead = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        if (facingRight)
            facing = 0;
        else
            facing = 180;

        transform.rotation = Quaternion.Euler(transform.rotation.x, facing, transform.rotation.z);
    }
}
