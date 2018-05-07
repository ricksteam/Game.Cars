using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    /*
     * This script is responsible for only playing 
     * a background music
     */ 


    new AudioSource audio;
    public string[] AudioNames;

    // Use this for initialization
    void Start ()
    {
        int i = Random.Range(0, AudioNames.Length); //random number to pick music randomly
        audio = gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.volume = .4f;
        audio.clip = Resources.Load("Audio/" + AudioNames[i]) as AudioClip;
        audio.loop = true;
        audio.Play();
    }
	
	
}
