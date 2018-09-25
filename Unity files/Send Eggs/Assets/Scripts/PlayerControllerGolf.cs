using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGolf : MonoBehaviour {

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

    public GameObject club;
    private Vector3 mousePos;
    private Vector3 mouseStartPos;
    private Vector3 playerStartPos;
    private Vector3 mouseMove;
    private Camera cam;
    public float hitForce;

    // Use this for initialization
    void Awake ()
    {
        Cursor.visible = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        gm = GameObject.Find("GameManager").GetComponent<GM>();

        rb2d = GetComponent<Rigidbody2D>();
        body = transform.GetChild(0).GetChild(0).gameObject;
        anim = transform.GetChild(0).GetComponent<Animator>();
        groundCheck = transform.GetChild(1).transform;

        Flip();

        club = GameObject.Find("Club");
        mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
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

        /*
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
        */
    }

    void Update()
    {
        animSpeed = rb2d.velocity.x / 3;
        anim.SetFloat("RollSpeed", animSpeed);

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

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (grounded)
            {
                club.SetActive(true);

                club.transform.up = body.transform.position - club.transform.position;

                mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                mouseMove = mousePos - mouseStartPos;
                club.transform.position = body.transform.position + mouseMove;

                hitForce = Vector2.Distance(club.transform.position, body.transform.position) * 3;
            }
        }
        else
        {
            rb2d.AddForce(club.transform.up * hitForce, ForceMode2D.Impulse);
            club.transform.position = body.transform.position;
            hitForce = 0;
            mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            mouseMove = Vector3.zero;
            club.SetActive(false);
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
