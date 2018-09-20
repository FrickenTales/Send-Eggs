using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrap : MonoBehaviour {

    private Animator bridgeAnim;
    public bool isOn = false;

    // Use this for initialization
    void Start ()
    {
        bridgeAnim = GameObject.FindGameObjectWithTag("Bridge").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isOn)
        {
            bridgeAnim.SetBool("IsOpen", true);
        }
        else
        {
            bridgeAnim.SetBool("IsOpen", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOn = true;
        }
    }
}
