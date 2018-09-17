using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickActivate : MonoBehaviour {

    private Vector3 onState = new Vector3(0, 5, 0);
    private Vector3 offState = new Vector3(0, 32, 0);
    private GameObject button;
    public bool isOn = false;
    public LeverClickActivate lvrClick;

    // Use this for initialization
    void Start()
    {
        button = transform.GetChild(0).GetChild(0).gameObject;
        lvrClick = GameObject.Find("ClickLever").GetComponent<LeverClickActivate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            button.transform.localPosition = onState;
            GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>().ready = true;
            GameObject.FindGameObjectWithTag("Stove").GetComponent<StoveScript>().isOn = true;
        }
        else
        {
            button.transform.localPosition = offState;
            GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>().ready = false;
            GameObject.FindGameObjectWithTag("Stove").GetComponent<StoveScript>().isOn = false;
        }
    }

    private void OnMouseDown()
    {
        if (lvrClick.leverActive == true)
        {
            isOn = true;
        }
    }
}