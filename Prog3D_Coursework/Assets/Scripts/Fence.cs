using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fence : MonoBehaviour
{
    [SerializeField] private UnityEvent voiceCallEvent;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            voiceCallEvent.Invoke();
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
