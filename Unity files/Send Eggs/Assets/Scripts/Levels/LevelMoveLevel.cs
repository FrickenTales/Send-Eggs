using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMoveLevel : MonoBehaviour {

    private GameObject shell;
    private Animator cartonanim;
    private PlayerController player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    public GameObject wholeLevel;
    private float xPos;
    private float yPos;

    // Use this for initialization
    void Awake()
    {

    }

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
        gm.ResetAssets();
        wholeLevel = GameObject.Find("Level_Layout");
        player = transform.GetChild(0).GetComponent<PlayerController>();
        Invoke("Begin", 0.1f);
    }

    void Begin()
    {
        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();
        

        //player base stats
        player.maxSpeed = 0;
        player.jumpForce = 0;
        player.maxFallSpeed = -18;
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

        Invoke("SpawnPlayer", 0.05f);
    }

    void KillPlayer()
    {
        Instantiate(shell, player.body.transform.position, player.body.transform.rotation);
        gm.deathCount++;
        xPos = 0;
        yPos = 0;
        Begin();
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
        wholeLevel.transform.position = new Vector3(xPos, yPos, 0);

        if (!gm.holdPlayer)
        {
            xPos += (Input.GetAxis("Horizontal") * Time.deltaTime * 10);
            yPos += (Input.GetAxis("Vertical") * Time.deltaTime * 20);
        }

        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
    }
}

