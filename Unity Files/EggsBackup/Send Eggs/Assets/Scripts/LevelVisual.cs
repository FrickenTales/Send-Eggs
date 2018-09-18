using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class LevelVisual : MonoBehaviour {

    public string LevelName = "Send Eggs";
    private Text levelNameText;
    [Tooltip("use HSV XX,38,66 to keep the aesthetic consistent")]
    public Color levelTileColour;
    [Tooltip("use HSV XX,12,85 becuase it looks nice")]
    public Color levelBackgroundColour;
    private Camera cam;
    private SpriteRenderer bgImage;
    private Tilemap tilemap;

    // Use this for initialization
    void Start ()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        levelNameText = GameObject.Find("LevelName").GetComponent<Text>();
        levelNameText.text = LevelName;
        tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        bgImage = GameObject.Find("BG Image").GetComponent<SpriteRenderer>();

        tilemap.color = levelTileColour;
        cam.backgroundColor = levelBackgroundColour;
        bgImage.color = levelBackgroundColour;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
