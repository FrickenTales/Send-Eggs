using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;
    public float jumpForce;
    private bool facingRight;
    private Rigidbody2D rb2d;
    private GameObject body;
    private float facing;
    private Animator anim;

    private bool grounded;
    public Transform groundCheck;
    private float groundRadius = 0.15f;
    public LayerMask whatisGround;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        body = transform.GetChild(0).gameObject;
        anim = GetComponent<Animator>();

        Flip();
	}
	

	void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatisGround);



        float move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        if (Mathf.Abs(rb2d.velocity.x) < 0.5f)
            anim.SetBool("IsIdle", true);
        else
            anim.SetBool("IsIdle", false);
    }

    void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2d.AddForce(new Vector2(0, jumpForce));
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
