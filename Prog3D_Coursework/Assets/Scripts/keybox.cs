using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keybox : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private UnityEvent _event;
        
    [SerializeField] private GameObject Strike;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                    _event.Invoke();
                    Debug.Log("Keybox play audio");
                    GameManager.Instance.KeyboxComplete = true; 
                    gameObject.SetActive(false);
                    Strike.SetActive(true); 
            }
        }
    }
    
}
