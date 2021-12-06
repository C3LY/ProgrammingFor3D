using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsEntrance : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip entrance;

    [SerializeField] private GameObject strikeUI;

    private bool hasAlreadyPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !hasAlreadyPlayed && !audioSource.isPlaying)
        {
            Debug.Log("entrance audio should play");
            audioSource.Play();
            strikeUI.SetActive(true);
            hasAlreadyPlayed = true;
        }
    }
}
