using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fence : MonoBehaviour
{
    [SerializeField] private UnityEvent voiceCallEvent;
	private bool hasAlreadyPlayed = false;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            if(!hasAlreadyPlayed)
            { 
                voiceCallEvent.Invoke(); 
                hasAlreadyPlayed = true; 
            }
            if (GameManager.Instance.KeyboxComplete)
            {
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                        GetComponent<Animator>().SetBool("FenceOpen", true); 
                }
            }
        }
    }
}
