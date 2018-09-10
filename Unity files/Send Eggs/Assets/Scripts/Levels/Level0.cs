using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : MonoBehaviour {

    public PlayerController player;
    public WinObjective pan;
    public ButtonScript panButton;
    public Transform playerSpawn;

	// Use this for initialization
	void Start ()
    {
        //player base stats
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.maxSpeed = 9;
        player.jumpForce = 9;
        player.canDoubleJump = false;

        //pan
        pan = GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>();
        pan.ready = false;

        //pan button
        panButton = GameObject.FindGameObjectWithTag("PanButton").GetComponent<ButtonScript>();

        //spawn point
        playerSpawn = GameObject.Find("SpawnPoint").transform;

        SpawnPlayer();
	}

    void SpawnPlayer()
    {
        player.transform.position = playerSpawn.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
}
