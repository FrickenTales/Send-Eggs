using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrap : MonoBehaviour {

    public GameObject player;
    public PlayerController cntrl;
    private Animator anim;
    public bool isOn = false;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player_Rolling");
        cntrl = player.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            anim.SetBool("isOn", true);
        }
        else
        {
            anim.SetBool("isOn", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOn = true;
            Invoke("kill", 0.4f);
        }
    }

    void kill()
    {
        cntrl.isDead = true;
    }
}
