using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keybox : MonoBehaviour
{
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
                {
                    _audioSource.Play();
                    gameObject.SetActive(false);
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
