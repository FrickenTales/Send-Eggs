using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {

    private Animator anim;
    private bool isOn = false;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isOn)
            anim.SetBool("isOn", true);
        else
            anim.SetBool("isOn", false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isOn = !isOn;
        }
    }
}
