using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System;

public class GM : MonoBehaviour {

    public bool testing;

    public float levelColour;
    public int currentLevel;
    public int deathCount;
    public Tilemap tilemap;
    public Camera cam;
    private Text deathCountText;
    private GameObject levelManager;
    private Component currentLevelScript;
    private string levelScriptName;
    public WinScreen winScreen;

    public bool holdPlayer = false;


	// Use this for initialization
	void Start ()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        levelColour = UnityEngine.Random.Range(0.0f, 1.0f);

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
        tilemap.color = Color.HSVToRGB(levelColour, .38f, .66f);
        cam.backgroundColor = Color.HSVToRGB(levelColour, .12f, .85f);
    }

    public void NewLevel()
    {       
        currentLevel++;
        Destroy(currentLevelScript);
        levelScriptName = ("Level" + currentLevel);
        levelManager.AddComponent(Type.GetType(levelScriptName));
        levelColour = UnityEngine.Random.Range(0.0f, 1.0f);
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
