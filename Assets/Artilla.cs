using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artilla : MonoBehaviour
{
    private AudioSource Sounds;    
    public AudioClip beep;

    private void Start()
    {
        Sounds = gameObject.GetComponent<AudioSource>();
    }

    void playBeep()
    {
        Sounds.PlayOneShot(beep, 1.0f);
    }
}
