using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

    public PlayerController player;
    public WinObjective pan;
    public ButtonScript panButton;
    public Transform playerSpawn;

    // Use this for initialization
    void Start()
    {
        //player base stats
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.maxSpeed = 15;
        player.jumpForce = 11;
        player.canDoubleJump = true;

        //pan
        pan = GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>();
        pan.ready = false;

        //pan button
        panButton = GameObject.FindGameObjectWithTag("PanButton").GetComponent<ButtonScript>();
        panButton.isOn = false;

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
    void Update()
    {

    }
}
