using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour {

    public float time;
    public int deaths;

    public GM gm;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);

        gm = GameObject.Find("GameManager").GetComponent<GM>();
    }
	
    

	// Update is called once per frame
	void Update ()
    {
        time = Time.time;
        deaths = gm.deathCount;
	}
}
