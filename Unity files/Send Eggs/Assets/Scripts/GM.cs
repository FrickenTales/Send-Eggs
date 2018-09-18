using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;

public class GM : MonoBehaviour {

    public bool testing;

    public int currentLevel;
    public int deathCount;
    private Text testText;
    private Text deathCountText;
    private Component currentLevelScript;
    //private string levelScriptName;
    public WinScreen winScreen;

    public GameObject[] mainAssets = new GameObject[7];
    public GameObject[] levels;

    public bool holdPlayer = false;


	// Use this for initialization
	void Start ()
    {
        mainAssets[0] = GameObject.Find("Button_Master");
        mainAssets[1] = GameObject.Find("Spikes_Master");
        mainAssets[2] = GameObject.Find("Lever_Master");
        mainAssets[3] = GameObject.Find("Stove_Master");
        mainAssets[4] = GameObject.Find("EggCarton_Master");
        mainAssets[5] = GameObject.Find("Frypan_Master");
        mainAssets[6] = GameObject.Find("Bridge_Master");

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
    }
	
	// Update is called once per frame
	void Update ()
    {
        deathCountText.text = (deathCount + " Deaths");
    }

    public void NewLevel()
    {       
        currentLevel++;
        Destroy(transform.GetChild(0).gameObject);
        DestroyAllObjects();
        Instantiate(Resources.Load("Levels/Level_" + currentLevel), transform);

        foreach(GameObject asset in mainAssets)
        {
            asset.SetActive(true);
        }

        Invoke("ReleasePlayer", 1.2f);
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
    }
}
