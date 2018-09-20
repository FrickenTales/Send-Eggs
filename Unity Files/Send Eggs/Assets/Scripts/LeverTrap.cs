using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrap : MonoBehaviour {

    public GameObject player;
    public PlayerController cntrl;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player_Rolling");
        cntrl = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cntrl.isDead = true;
        }
    }
}
