using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuskScript : MonoBehaviour {

    private GameObject shell;
    private GameObject body;
    private Rigidbody2D rb2d;

    private bool willDie = false;

    // Use this for initialization
    void Start ()
    {
        body = transform.GetChild(0).gameObject;
        rb2d = GetComponent<Rigidbody2D>();
        shell = Resources.Load("BrokenEgg") as GameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(rb2d.velocity.y < -12)
        {
            willDie = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (willDie)
        {
            Instantiate(shell, body.transform.position, body.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Instantiate(shell, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
