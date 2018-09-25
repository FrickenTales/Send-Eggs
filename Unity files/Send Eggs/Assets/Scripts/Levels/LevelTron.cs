using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTron : MonoBehaviour {

    private GameObject shell;
    private Animator cartonanim;
    private PlayerControllerTron player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    private TrailRendererWith2DCollider trail;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start ()
    {
        trail = GameObject.Find("TrailHost").GetComponent<TrailRendererWith2DCollider>();
        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        player = transform.GetChild(0).GetComponent<PlayerControllerTron>();
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
        trail.lifeTime = 0f;
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
        Invoke("NewTrail", 0.1f);
    }

    void NewTrail()
    {
        trail.lifeTime = 60f;
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
