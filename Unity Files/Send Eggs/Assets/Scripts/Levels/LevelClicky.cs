using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClicky : MonoBehaviour
{

    private GameObject shell;
    private Animator cartonanim;
    private PlayerController player;
    private WinObjective pan;
    private ButtonClickScript panButton;
    private Transform playerSpawn;
    private LeverClickScript lever;
    private GM gm;

    private bool first = true;
    private GameObject oldButton;
    private GameObject oldLever;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;

        if (first)
        {
            oldButton = GameObject.Find("Button_Master");
            oldLever = GameObject.Find("Lever_Master");
            oldButton.SetActive(false);
            oldLever.SetActive(false);
            first = false;
        }

        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        player = transform.GetChild(0).GetComponent<PlayerController>();
        player.maxSpeed = 9;
        player.jumpForce = 11;
        player.canDoubleJump = false;

        //pan
        pan = GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>();
        pan.ready = false;

        //pan button
        panButton = GameObject.FindGameObjectWithTag("PanButton").GetComponent<ButtonClickScript>();
        panButton.isOn = false;

        //bridge lever
        lever = GameObject.FindGameObjectWithTag("Lever").GetComponent<LeverClickScript>();
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
        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
    }
}
