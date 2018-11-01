using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartonSound : MonoBehaviour
{

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}