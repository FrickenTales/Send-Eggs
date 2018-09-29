using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndStats : MonoBehaviour {

    public StatTracker statTracker;
    private Text numbertext;

	// Use this for initialization
	void Start ()
    {
        statTracker = GameObject.Find("StatTracker").GetComponent<StatTracker>();
        numbertext = GetComponent<Text>();

        numbertext.text = statTracker.deaths.ToString();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
