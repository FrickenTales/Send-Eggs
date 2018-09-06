using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour {

    private Rigidbody2D rb2d;
    private GameObject body;
    private float bodyRotation;
    public float moveSpeed;
    public float jumpPower;

    private Animator animator;
    private float moverot;

	// Use this for initialization
	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        body = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();

        moverot = 90;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed * 0.1f;
        bodyRotation = Input.GetAxis("Horizontal") * 10;
        bodyRotation = Mathf.Abs(bodyRotation);
        body.transform.rotation = Quaternion.Euler(bodyRotation, moverot, 0);

        rb2d.MovePosition(new Vector2(transform.position.x + x, transform.position.y));

        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("IsIdle", false);

            if (Input.GetAxis("Horizontal") > 0)
            {
                moverot = 90;
            }
            else
            {
                moverot = -90;
            }
        }
        else
        {
            animator.SetBool("IsIdle", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rb2d.velocity = new Vector2(0, rb2d.velocity.y + jumpPower);

            rb2d.AddForce(Vector2.up * jumpPower);
        }

    }
}
