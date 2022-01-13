using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndComputer : MonoBehaviour
{

    [SerializeField] private GameObject hackingSystemUI;
    [SerializeField] private GameObject completeUI;
    [SerializeField] private GameObject StrikeUI;
    [SerializeField] private UnityEvent voiceCallEvent;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hackingSystemUI.SetActive(true);
                StartCoroutine(finishedHacking());
            }
        }
    }

    private IEnumerator finishedHacking()
    {
        yield return new WaitForSeconds(5);
        
        hackingSystemUI.SetActive(false);
        completeUI.SetActive(true);
        completeUI.GetComponent<Animator>().SetTrigger("Complete");
        StrikeUI.SetActive(true);
        voiceCallEvent.Invoke();
    }
}
