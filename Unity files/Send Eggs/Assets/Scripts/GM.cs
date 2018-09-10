using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

    public int currentLevel;
    public GameObject player;
    public Transform playerSpawnPoint;
    public WinScreen winScreen;
    private WinObjective winObj;

    public bool holdPlayer = false;


	// Use this for initialization
	void Start ()
    {
        winObj = GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>();
        winObj.ready = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void NewLevel()
    {       
        currentLevel++;
        player.transform.position = playerSpawnPoint.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Invoke("ReleasePlayer", 2.0f);
        winObj.ready = true;
    }

    public void WinCanvas()
    {
        winScreen.Change();
    }

    void ReleasePlayer()
    {
        holdPlayer = false;
    }
}
