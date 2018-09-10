using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GM : MonoBehaviour {

    public int currentLevel;
    private GameObject levelManager;
    private Component currentLevelScript;
    private string levelScriptName;
    public WinScreen winScreen;

    public bool holdPlayer = false;


	// Use this for initialization
	void Start ()
    {
        levelScriptName = ("Level" + currentLevel);
        levelManager = GameObject.Find("LevelManager");
        levelManager.AddComponent(Type.GetType(levelScriptName));
        currentLevelScript = levelManager.GetComponent(Type.GetType(levelScriptName));
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void NewLevel()
    {       
        currentLevel++;
        Destroy(currentLevelScript);
        levelScriptName = ("Level" + currentLevel);
        levelManager.AddComponent(Type.GetType(levelScriptName));
        //levelManager.SetActive(false); levelManager.SetActive(true); // reset level manager to force script to enable, there's probably a batter way




        Invoke("ReleasePlayer", 2.0f);
        //winObj.ready = true;
    }

    public void WinCanvas()
    {
        winScreen.Change();
    }

    void ReleasePlayer()
    {
        holdPlayer = false;
    }
}
