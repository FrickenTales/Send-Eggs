using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour {

    public float lifetimeMin = 4;
    public float lifetimeMax = 6;

	// Use this for initialization
	void Start ()
    {
        Invoke("Kill", Random.Range(lifetimeMin, lifetimeMax));
	}

    void Kill ()
    {
        Destroy(this.gameObject);
	}
}
