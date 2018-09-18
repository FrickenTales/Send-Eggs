using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour {

    public Image bgImage;
    public Text winMessage;
    public string[] texts;
    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
	}
	
	public void Change ()
    {
        anim.SetTrigger("PlayWinScreen");
        bgImage.color = Random.ColorHSV(0, 1, 0.21f, 0.21f, 0.86f, 0.86f, 1, 1);
        winMessage.text = texts[Random.Range(0, texts.Length)];
	}
}
