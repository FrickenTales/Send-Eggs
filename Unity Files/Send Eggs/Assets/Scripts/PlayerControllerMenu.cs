using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMenu : MonoBehaviour
{
    public float maxSpeed;
    public float move;

    public Rigidbody2D rb2d;
    public Animator anim;
    public float animSpeed;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        move = Mathf.Lerp(move, 1, Time.deltaTime * 2.3f);

        rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

        animSpeed = rb2d.velocity.x / 4.5f;

        anim.SetFloat("RollSpeed", animSpeed);

    }

}
    


