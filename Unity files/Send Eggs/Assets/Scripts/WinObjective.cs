using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObjective : MonoBehaviour {

    public bool ready = false;
    private GM gm;

    private float safetyWait = 0;
    private float safety = 2;

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (ready)
            {
                WinLevel();
                /*
                if (Time.time > safetyWait)
                {
                    WinLevel();
                }
                */
            }
        }
    }

    public void WinLevel()
    {
        if (Time.time > safetyWait)
        {
            safetyWait = Time.time + safety;
            ready = false;
            gm.holdPlayer = true;
            print("win");
            gm.WinCanvas();
            Invoke("TellGM", 0.7f);
        }
    }

    void TellGM()
    {
        gm.NewLevel();
    }
}
