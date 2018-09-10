using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public Color onColour;
    public Color offColour;
    public bool isOn = false;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isOn)
            sr.color = onColour;
        else
            sr.color = offColour;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isOn)
            {
                isOn = true;
                GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>().ready = true;
            }
        }
    }
}
