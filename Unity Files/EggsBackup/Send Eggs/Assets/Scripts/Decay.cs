using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour {

    public float lifetime = 4;
    public bool shrink = false;
    private float scale = 1;

	// Use this for initialization
	void Start ()
    {
        Invoke("Shrink", lifetime / 2);
        Invoke("Kill", lifetime);
	}

    private void Update()
    {
        transform.localScale = new Vector3(scale, scale, scale);
        if (shrink)
        {
            scale -= 0.007f;
        }
    }

    void Shrink()
    {
        shrink = true;
    }

    void Kill ()
    {
        Destroy(this.gameObject);
	}
}
