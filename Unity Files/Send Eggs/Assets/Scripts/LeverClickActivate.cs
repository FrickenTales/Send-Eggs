using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverClickActivate : MonoBehaviour {

    public bool toggles = true;
    private Animator anim;
    private Animator bridgeAnim;
    public bool isOn = false;
    public bool leverActive = false;

	// Use this for initialization
	void Start ()
    {
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
            leverActive = true;
        }
        else
        {
            anim.SetBool("isOn", false);
            bridgeAnim.SetBool("IsOpen", false);
            leverActive = false;
        }

	}

    private void OnMouseDown()
    {
        isOn = true;
    }
}
