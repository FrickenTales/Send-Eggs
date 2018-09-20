using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptScared : MonoBehaviour {

    private Vector3 onState = new Vector3(0,0.32f,0);
    private Vector3 offState = new Vector3(0, 0.87f, 0);
    private GameObject button;
    public bool isOn = false;

	// Use this for initialization
	void Start ()
    {
        button = transform.GetChild(0).gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isOn)
        {
            button.transform.localPosition = onState;
            GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjectiveScared>().ready = true;
            GameObject.FindGameObjectWithTag("Stove").GetComponent<StoveScript>().isOn = true;
        }
        else
        {
            button.transform.localPosition = offState;
            GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjectiveScared>().ready = false;
            GameObject.FindGameObjectWithTag("Stove").GetComponent<StoveScript>().isOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!isOn)
            {
                isOn = true;
            }
        }
    }
}
