using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SystemsEntrance : MonoBehaviour
{
    [SerializeField] private UnityEvent voiceCallEvent;
    [SerializeField] private GameObject strikeUI;

    private bool hasAlreadyPlayed = false;

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !hasAlreadyPlayed)
        {
            voiceCallEvent.Invoke();
            strikeUI.SetActive(true);
            hasAlreadyPlayed = true;
        }
    }
}
