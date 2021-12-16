using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voice_Call : MonoBehaviour
{
    [SerializeField] private AudioClip IntroAudio;
    [SerializeField] private AudioClip checkChute;
    [SerializeField] private AudioClip checkUpstairs;
    [SerializeField] private AudioClip headForExit;
    [SerializeField] private AudioClip foundKeyBox;
    [SerializeField] private AudioClip foundGrenade;
    [SerializeField] private AudioClip finishedJob;
    [SerializeField] private AudioClip carefulRobots;
    [SerializeField] private AudioClip foundSystemRoom;
    [SerializeField] private AudioClip uhOhAlarm;
    [SerializeField] private AudioClip youHaventFoundKeyboxFence;
    [SerializeField] private AudioClip useTheKeyboxFence;
    private AudioSource audioSource;

    public void playKeybox()
    {
        Debug.Log("keybox audio ");
        audioSource.clip = foundKeyBox;
        audioSource.Play();
    }
    
    public void playAlarm()
    {
        Debug.Log("alarm audio");
        audioSource.clip = uhOhAlarm;
        audioSource.Play();
    }
    
    public void playGrenade()
    {
        Debug.Log("grenade found audio ");
        audioSource.clip = foundGrenade;
        audioSource.Play();
    }


    public void playSystemsRoom()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = foundSystemRoom;
            audioSource.Play();
        }
    }

    public void playFinishedJob()
    {
        audioSource.clip = finishedJob;
        audioSource.Play();   
    }

    public void playOpenFence()
    {
        if (GameManager.Instance)
        {
            if (GameManager.Instance.KeyboxComplete == false)
            {
                audioSource.clip = youHaventFoundKeyboxFence;
            }
            else
            {
                audioSource.clip = useTheKeyboxFence;
            }
            audioSource.Play(); 
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
