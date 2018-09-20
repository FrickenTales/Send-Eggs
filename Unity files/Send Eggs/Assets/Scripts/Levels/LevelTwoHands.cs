using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoHands : MonoBehaviour {

    private GameObject shell;
    private Animator cartonanim;
    private PlayerControllerTH player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    private bool pressingD;
    private bool pressingA;
    private bool pressingW;
    private bool pressingRight;
    private bool pressingLeft;
    private bool pressingUp;

    // Use this for initialization
    void Start()
    {
        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        player = transform.GetChild(0).GetComponent<PlayerControllerTH>();
        player.maxSpeed = 9;
        player.jumpForce = 11;
        player.canDoubleJump = false;

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
        if (Input.GetKey(KeyCode.D))
            pressingD = true;
        else
            pressingD = false;

        if (Input.GetKey(KeyCode.W))
            pressingW = true;
        else
            pressingW = false;

        if (Input.GetKey(KeyCode.A))
            pressingA = true;
        else
            pressingA = false;

        if (Input.GetKey(KeyCode.RightArrow))
            pressingRight = true;
        else
            pressingRight = false;

        if (Input.GetKey(KeyCode.UpArrow))
            pressingUp = true;
        else
            pressingUp = false;

        if (Input.GetKey(KeyCode.LeftArrow))
            pressingLeft = true;
        else
            pressingLeft = false;

        if((pressingD && pressingRight) || (pressingA && pressingLeft))
        {
            player.canMove = true;
        }
        else
        {
            player.canMove = false;
        }

        if(pressingW && pressingUp)
        {
            player.canJump = true;
        }
        else
        {
            player.canJump = false;
        }


        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
    }
}
