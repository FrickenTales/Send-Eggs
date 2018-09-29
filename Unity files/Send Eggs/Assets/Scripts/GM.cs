using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public bool testing;

    public int currentLevel;
    public int deathCount;
    private Text testText;
    private Text deathCountText;
    private Component currentLevelScript;
    //private string levelScriptName;
    public WinScreen winScreen;
    private GameObject wholeLevel;

    public GameObject[] mainAssets = new GameObject[7];
    public GameObject[] levels;

    private GameObject pauseUI;
    private bool paused = false;

    public bool holdPlayer = false;

    private GameObject cam;

	// Use this for initialization
	void Start ()
    {
        cam = GameObject.Find("Main Camera");

        mainAssets[0] = GameObject.Find("Button_Master");
        mainAssets[1] = GameObject.Find("Spikes_Master");
        mainAssets[2] = GameObject.Find("Lever_Master");
        mainAssets[3] = GameObject.Find("Stove_Master");
        mainAssets[4] = GameObject.Find("EggCarton_Master");
        mainAssets[5] = GameObject.Find("Frypan_Master");
        mainAssets[6] = GameObject.Find("Bridge_Master");

        pauseUI = GameObject.Find("PauseUI");
        winScreen = GameObject.Find("LevelCompleteCanvas").GetComponent<WinScreen>();
        wholeLevel = GameObject.Find("Level_Layout");

        testText = GameObject.Find("TestText").GetComponent<Text>();
        deathCountText = GameObject.Find("DeathCounter").GetComponent<Text>();

        if (!testing)
        {
            if (transform.childCount > 0)
                Destroy(transform.GetChild(0).gameObject);

            testText.enabled = false;
            //levelScriptName = ("Level" + currentLevel);
            //Instantiate(Resources.Load("Levels/Level_" + currentLevel), transform);
            Instantiate(levels[currentLevel], transform);
        }
        else
        {
            currentLevel = 999;
            testText.enabled = true;
        }

        pauseUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        deathCountText.text = (deathCount + " Deaths");


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }

        if(currentLevel == levels.Length)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    public void NewLevel()
    {
        Cursor.visible = true;
        cam.transform.eulerAngles = new Vector3(0, 0, 0);
        ResetAssets();
        wholeLevel.transform.position = new Vector3(0, 0, 0);
        currentLevel++;
        Destroy(transform.GetChild(0).gameObject);
        DestroyAllObjects();
        //Instantiate(Resources.Load("Levels/Level_" + currentLevel), transform);
        Instantiate(levels[currentLevel], transform);

        Invoke("ReleasePlayer", 1.2f);
    }

    public void ResetAssets()
    {
        foreach (GameObject asset in mainAssets)
        {
            asset.SetActive(true);
        }
    }

    public void WinCanvas()
    {
        winScreen.Change();
    }

    void ReleasePlayer()
    {
        holdPlayer = false;
    }

    void DestroyAllObjects()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag("Corpse");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

        var gameObjects2 = GameObject.FindGameObjectsWithTag("Player");

        for (var i = 0; i < gameObjects2.Length; i++)
        {
            Destroy(gameObjects2[i]);
        }
    }
}
