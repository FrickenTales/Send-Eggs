using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour {

    private string LevelName = "sggE dneS";
    private Text levelNameText;
    private PlayerController player;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private GM gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GM>();
        levelNameText = GameObject.Find("LevelName").GetComponent<Text>();
        levelNameText.text = LevelName;

        //player base stats
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
        //inverts facing direction
        //player.body.transform.rotation = Quaternion.Euler(player.body.transform.rotation.x, player.facing * -1, player.body.transform.rotation.z);

        if (player.isDead)
        {
            player.isDead = false;
            KillPlayer();
        }
    }
}
