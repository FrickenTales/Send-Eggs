using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRocket : MonoBehaviour {

    public float maxSpeed;
    public float turnSpeed;
    public bool isDead = false;
    public Rigidbody2D rb2d;
    public GameObject body;
    public Animator anim;

    public GameObject flame;

    public bool ready;
    //public float animSpeed;

    private GM gm;

    // Use this for initialization
    void Awake ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
        flame = transform.GetChild(0).GetChild(3).gameObject;

        rb2d = GetComponent<Rigidbody2D>();
        body = transform.GetChild(0).GetChild(0).gameObject;
        anim = transform.GetChild(0).GetComponent<Animator>();

	}
	

	void FixedUpdate ()
    {
        if (ready)
        {
            rb2d.gravityScale = 0;

            rb2d.AddForce(transform.up * maxSpeed);

            rb2d.AddTorque(-Input.GetAxis("Horizontal") * turnSpeed);

            flame.SetActive(true);
        }
        else
        {
            flame.SetActive(false);
            rb2d.gravityScale = 2;
        }
        
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            ready = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            isDead = true;
        }
    }

}
