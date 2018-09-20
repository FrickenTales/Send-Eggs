using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScarePan : MonoBehaviour {

    private GameObject shell;
    private Animator cartonanim;
    private PlayerController player;
    private WinObjectiveScared pan;
    private ButtonScriptScared panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    private void Awake()
    {
        GameObject.Find("Frypan_Master").SetActive(false);
        GameObject.Find("Button_Master").SetActive(false);
    }

    // Use this for initialization
    void Start ()
    {
        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        player = transform.GetChild(0).GetComponent<PlayerController>();
        player.maxSpeed = 9;
        player.jumpForce = 11;
        player.canDoubleJump = false;

        //pan
        pan = GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjectiveScared>();
        pan.curPlace = 0;
        pan.transform.position = pan.places[0];
        pan.ready = false;

        //pan button
        panButton = GameObject.FindGameObjectWithTag("PanButton").GetComponent<ButtonScriptScared>();
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
	void Update ()
    {
        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
	}
}
