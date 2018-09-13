using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {

    private PlayerController player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private GM gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        player = transform.GetChild(0).GetComponent<PlayerController>();
        player.maxSpeed = -9;
        player.jumpForce = 11;
        player.canDoubleJump = false;

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

    void KillPlayer()
    {
        gm.deathCount++;
        Start();
        //SpawnPlayer();
    }

    void SpawnPlayer()
    {
        player.transform.position = playerSpawn.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
    }
}
