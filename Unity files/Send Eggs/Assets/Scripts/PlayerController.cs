using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;
    public float jumpForce;
    public bool canDoubleJump;

    private bool facingRight;
    private Rigidbody2D rb2d;
    private GameObject body;
    private float facing;
    private Animator anim;

    private bool grounded;
    private Transform groundCheck;
    private Vector2 groundCap = new Vector2 (0.8f,0.35f);
    //private float groundRadius = 0.15f;
    public LayerMask whatisGround;

    private bool doubleJump = false;

    private GM gm;

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        rb2d = GetComponent<Rigidbody2D>();
        body = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();
        groundCheck = transform.GetChild(1).transform;

        Flip();
	}
	

	void FixedUpdate ()
    {
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatisGround);
        grounded = Physics2D.OverlapCapsule(groundCheck.position, groundCap, CapsuleDirection2D.Horizontal, 90, whatisGround);

        if (grounded && canDoubleJump)
            doubleJump = false;

        if (!gm.holdPlayer)
        {
            float move = Input.GetAxis("Horizontal");

            rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
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

        if((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rb2d.AddForce(new Vector2(0, jumpForce));
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            if (!doubleJump && !grounded)
                doubleJump = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        if (facingRight)
            facing = 90;
        else
            facing = -90;

        body.transform.rotation = Quaternion.Euler(body.transform.rotation.x, facing, body.transform.rotation.z);
    }
}
