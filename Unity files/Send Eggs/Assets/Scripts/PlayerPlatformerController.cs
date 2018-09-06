using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    //private SpriteRenderer spriteRenderer;
    private Animator animator;
    private GameObject body;

    // Use this for initialization
    void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        body = transform.GetChild(0).gameObject;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        targetVelocity = move * maxSpeed;

        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("IsIdle", false);

            if (Input.GetAxis("Horizontal") > 0)
            {
                body.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            else
            {
                body.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }
        else
        {
            animator.SetBool("IsIdle", true);
        }
    }


}
