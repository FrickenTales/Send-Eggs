using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSpeedrun : MonoBehaviour {

    private GameObject shell;
    private Animator cartonanim;
    private PlayerController player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    private float timeRemaining;
    private float totalTime;
    private Text timerText;
    private Canvas timerCanvas;

    private bool first = true;

    // Use this for initialization

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
        gm.ResetAssets();
        timerCanvas = transform.GetChild(1).GetComponent<Canvas>();
        timerCanvas.worldCamera = GameObject.Find("BackgroundCamera").GetComponent<Camera>();
        timerText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        player = transform.GetChild(0).GetComponent<PlayerController>();
        totalTime = 13.5f;

        Invoke("Begin", 0.1f);
    }

    void Begin()
    {
        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();

        //player base stats
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
        first = false;
    }

    void KillPlayer()
    {
        Instantiate(shell, player.body.transform.position, player.body.transform.rotation);
        gm.deathCount++;
        Begin();
        //SpawnPlayer();
    }

    void SpawnPlayer()
    {
        player.transform.position = playerSpawn.position;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        cartonanim.SetTrigger("SpawnEgg");
        player.anim.SetTrigger("Spawn");

        timeRemaining = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if(timeRemaining < 0)
        {
            if(!first)
                KillPlayer();
        }

        timerText.text = timeRemaining.ToString("F1");

        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
    }
}
