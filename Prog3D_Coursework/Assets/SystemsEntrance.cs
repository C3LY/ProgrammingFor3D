using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsEntrance : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private GameObject strikeUI;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            strikeUI.SetActive(true);
        }
    }
}
