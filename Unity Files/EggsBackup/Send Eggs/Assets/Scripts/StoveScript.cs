using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveScript : MonoBehaviour {

    private GameObject flames;
    public bool isOn = false; 

	// Use this for initialization
	void Start ()
    {
        flames = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isOn)
            flames.SetActive(true);
        else
            flames.SetActive(false);
	}
}
