using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinObjectiveScared : MonoBehaviour {

    public bool ready = false;
    private GM gm;

    private float safetyWait = 0;
    private float safety = 2;

    public int curPlace = 0;

    public Vector2[] places;

    // Use this for initialization
    void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(curPlace == 2)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
        }
        else if(curPlace == 3)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            transform.eulerAngles = new Vector3(0, 0, 226.31f);
        }
        else
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (ready)
            {
                if (curPlace == places.Length - 1)
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
                else
                {
                    transform.position = places[curPlace + 1];
                    curPlace++;
                }
            }
        }
    }

    void TellGM()
    {
        gm.NewLevel();
    }
}
