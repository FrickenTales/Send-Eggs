﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelVVVVVV : MonoBehaviour  
{

    private GameObject shell;
    private Animator cartonanim;
    private PlayerController player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    // Use this for initialization
    void Start()
    {
        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        player = transform.GetChild(0).GetComponent<PlayerController>();
        player.maxSpeed = 9;
        player.jumpForce = 5;
        player.canDoubleJump = false;
        player.rb2d.gravityScale = 2;

        //pan
        pan = GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>();
        pan.ready = false;

        //pan button
        panButton = GameObject.FindGameObjectWithTag("PanButton").GetComponent<ButtonScript>();
        panButton.isOn = false;

        //bridge lever
        lever = GameObject.FindGameObjectWithTag("Lever").GetComponent<LeverScript>();
        lever.toggles = false;
        lever.isOn = false;

        //spawn point
        playerSpawn = GameObject.Find("SpawnPoint").transform;

        SpawnPlayer();
    }

    void KillPlayer()
    {
        Instantiate(shell, player.body.transform.position, player.body.transform.rotation);
        gm.deathCount++;
        Start();
        //SpawnPlayer();
    }

    void SpawnPlayer()
    {
        player.transform.position = playerSpawn.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cartonanim.SetTrigger("SpawnEgg");
        player.anim.SetTrigger("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.grounded && Input.GetButtonDown("Jump"))
        {
            player.rb2d.gravityScale = -player.rb2d.gravityScale;
            player.jumpForce = -player.jumpForce;
        }

        if (player.rb2d.gravityScale < 0)
        {
            player.groundCheck.localPosition = new Vector3(0, 0.82f, 0);
            player.anim.SetFloat("RollSpeed", -player.animSpeed);
        }
        else
        {
            player.groundCheck.localPosition = new Vector3(0, 0.021f, 0);
            player.anim.SetFloat("RollSpeed", player.animSpeed);
        }

        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
    }
}
