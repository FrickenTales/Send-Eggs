using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GM : MonoBehaviour {

    public bool testing;

    public int currentLevel;
    public int deathCount;
    private Text deathCountText;
    private GameObject levelManager;
    private Component currentLevelScript;
    private string levelScriptName;
    public WinScreen winScreen;

    public bool holdPlayer = false;


	// Use this for initialization
	void Start ()
    {
        deathCountText = GameObject.Find("DeathCounter").GetComponent<Text>();

        if (!testing)
        {
            levelScriptName = ("Level" + currentLevel);
            levelManager = GameObject.Find("LevelManager");
            levelManager.AddComponent(Type.GetType(levelScriptName));
            currentLevelScript = levelManager.GetComponent(Type.GetType(levelScriptName));
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
        Destroy(currentLevelScript);
        levelScriptName = ("Level" + currentLevel);
        levelManager.AddComponent(Type.GetType(levelScriptName));
        //levelManager.SetActive(false); levelManager.SetActive(true); // reset level manager to force script to enable, there's probably a batter way




        Invoke("ReleasePlayer", 1.4f);
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
