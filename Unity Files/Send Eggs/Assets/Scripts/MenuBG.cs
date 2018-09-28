using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBG : MonoBehaviour
{
    public GameObject egg;
    public Animator cartonAnim;
    public Animator eggAnim;
    public PlayerControllerMenu pcMenu;

    public Transform eggStart;

    public bool ready;

	// Use this for initialization
	void Start ()
    {
        ready = false;
        //eggStart = egg.transform;

        InvokeRepeating("NewEgg", 0.01f, 5f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ready)
        {
            egg.GetComponent<Rigidbody2D>().AddForce(Vector2.right);
        }
	}

    void NewEgg()
    {
        ready = false;
        pcMenu.move = 0;
        egg.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        egg.transform.position = eggStart.position;
        cartonAnim.SetTrigger("SpawnEgg");
        eggAnim.SetTrigger("Spawn");

        //Invoke("readyUp", 1f);
    }

    void readyUp()
    {
        ready = true;
    }
}
