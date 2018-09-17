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

    public bool holdPlayer = false;


	// Use this for initialization
	void Start ()
    {
        testText = GameObject.Find("TestText").GetComponent<Text>();
        deathCountText = GameObject.Find("DeathCounter").GetComponent<Text>();

        if (!testing)
        {
            if (transform.childCount > 0)
                Destroy(transform.GetChild(0).gameObject);

            testText.enabled = false;
            //levelScriptName = ("Level" + currentLevel);
            Instantiate(Resources.Load("Levels/Level_" + currentLevel), transform);
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
