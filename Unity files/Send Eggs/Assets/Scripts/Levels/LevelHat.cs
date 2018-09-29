using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHat : MonoBehaviour {

    private GameObject shell;
    private Animator cartonanim;
    private PlayerController player;
    private GameObject hat;
    private GameObject egg;
    private WinObjective pan;
    private ButtonScript panButton;
    private Transform playerSpawn;
    private LeverScript lever;
    private GM gm;

    private float distance;
    private bool hatOff = false;
    private float countdown;
    private int levelDeaths;
    private bool showSkip = false;
    private Vector3 hatSpawn = new Vector3(-14.44f, 5.4f, -0.65f);
    public Text sorryText;
    private string[] sorry = new string[] { "We are very sorry for this level, it wasn't meant to be this hard. It's okay if you want to skip it. We did." };
    private int currentlyDisplayingText = 0;
    public Animator skipAnim;

    public Button skipButton;
    public GameObject skipUI;

    // Use this for initialization
    void Start ()
    {
        skipButton.onClick.AddListener(OnClickSkip);

        countdown = 2.5f;
        hat = transform.GetChild(1).gameObject;
        egg = transform.GetChild(0).gameObject;
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
        levelDeaths++;
        Instantiate(shell, player.body.transform.position, player.body.transform.rotation);
        gm.deathCount++;
        Start();
        //SpawnPlayer();
    }

    void SpawnPlayer()
    {
        player.transform.position = playerSpawn.position;
        hat.transform.position = hatSpawn;
        hat.transform.eulerAngles = Vector3.zero;
        hat.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        hat.GetComponent<Rigidbody2D>().angularVelocity = 0;
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

        distance = Vector2.Distance(egg.transform.position, hat.transform.position);

        if (hatOff)
        {
            hat.GetComponent<SpriteRenderer>().color = Color.red;
            countdown -= Time.deltaTime;
        }
        else
        {
            hat.GetComponent<SpriteRenderer>().color = Color.gray;
            countdown = 2.5f;
        }

        if(countdown < 0)
        {
            KillPlayer();
        }

        if(levelDeaths > 9)
        {
            if(!showSkip)
            {
                StartCoroutine(AnimateText());
            }

            showSkip = true;
        }

        if(distance > 1.8f)
        {
            hatOff = true;
        }
        else
        {
            hatOff = false;
        }

	}

    void OnClickSkip()
    {
        GameObject.FindGameObjectWithTag("Objective").GetComponent<WinObjective>().WinLevel();
        skipUI.SetActive(false);
    }

    IEnumerator AnimateText()
    {

        for (int i = 0; i < (sorry[currentlyDisplayingText].Length + 1); i++)
        {
            sorryText.text = sorry[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }
        skipAnim.SetTrigger("Spawn");
    }
}
