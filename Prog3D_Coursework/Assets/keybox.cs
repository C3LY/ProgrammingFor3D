using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class keybox : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private UnityEvent _event;
        
    [SerializeField] private GameObject Strike;
    // Start is called before the first frame update
    
    void Start()
    {
      //  _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
                {
                    _event.Invoke();
                    Debug.Log("imma play audio");
                    GameManager.Instance.KeyboxComplete = true; 
                    gameObject.SetActive(false);
                    Strike.SetActive(true);
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
