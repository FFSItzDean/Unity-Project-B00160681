//B00160681 Dean Smith
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;  //singleton instance to persist between scenes
    private AudioSource audioSource;

    void Awake()
    {
        //check if instance exists and handle duplicates
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  //keep music between scenes
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //control volume
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
