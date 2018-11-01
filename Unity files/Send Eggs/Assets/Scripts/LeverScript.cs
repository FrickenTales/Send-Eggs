using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour {

    public bool toggles = false;
    private Animator anim;
    private Animator bridgeAnim;
    public bool isOn = false;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bridgeAnim = GameObject.FindGameObjectWithTag("Bridge").GetComponent<Animator>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isOn)
        {
            anim.SetBool("isOn", true);
            bridgeAnim.SetBool("IsOpen", true);
        }
        else
        {
            anim.SetBool("isOn", false);
            bridgeAnim.SetBool("IsOpen", false);
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (toggles)
            {
                isOn = !isOn;
                audioSource.Play();
            }
            else
            {
                if (!isOn)
                    audioSource.Play();
                isOn = true;               
            }
        }
    }
}
