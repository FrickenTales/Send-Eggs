using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPnC : MonoBehaviour {

    private GameObject shell;
    private Animator cartonanim;
    private PlayerController player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    private GameObject playerObject;
    private Transform clicked;
    private Vector3 mousePos;
    private Vector3 move;
    private Camera cam;

    private Vector3 mouseStartPos;
    private Vector3 playerStartPos;

    private void Awake()
    {
        Cursor.visible = false;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerObject = transform.GetChild(0).gameObject;
    }

    // Use this for initialization
    void Start ()
    {
        shell = Resources.Load("BrokenEgg") as GameObject;
        cartonanim = GameObject.FindGameObjectWithTag("Carton").GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GM>();

        //player base stats
        player = transform.GetChild(0).GetComponent<PlayerController>();
        player.maxSpeed = 0;
        player.jumpForce = 0;
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
        mouseStartPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
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
        //playerStartPos = player.transform.position;

        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        move = mousePos - mouseStartPos;
        playerObject.transform.position = playerSpawn.position + move;
        /*
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        playerObject.transform.position = pz;
        */


        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
	}
}
