//B00160681 Dean Smith
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;  //singleton instance
    private AudioSource audioSource;

    void Awake()
    {
        //ensure only one music player exists
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
