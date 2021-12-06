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
    [SerializeField] private AudioClip foundSystem;
    [SerializeField] private AudioClip uhOhAlarm;
    private AudioSource audioSource;

    public  void playKeybox()
    {
        Debug.Log("invoicecallplayingaudio");
        audioSource.clip = foundKeyBox;
        audioSource.Play();
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
