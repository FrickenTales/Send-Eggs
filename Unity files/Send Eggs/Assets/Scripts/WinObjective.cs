using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObjective : MonoBehaviour {

    public bool ready = false;
    private GM gm;

	// Use this for initialization
	void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (ready)
            {
                gm.holdPlayer = true;
                ready = false;
                print("win");
                gm.WinCanvas();
                Invoke("TellGM", 0.7f);
            }
        }
    }

    void TellGM()
    {
        gm.NewLevel();
    }
}
