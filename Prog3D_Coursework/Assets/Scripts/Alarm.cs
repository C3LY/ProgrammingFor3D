using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent voiceCallEvent;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.KeyboxComplete && GameManager.Instance.AlarmSet==false)
        {
            GameManager.Instance.AlarmSet = true;
            voiceCallEvent.Invoke();
            foreach(GameObject lightObject in GameObject.FindGameObjectsWithTag("HangingLight"))
            {
                Animator lightObjectAnim = lightObject.GetComponent<Animator>();
                    lightObjectAnim.SetBool("HangingLightStart", true);
                    StartCoroutine(alarmFlash(lightObjectAnim));
            }
            
            foreach(GameObject alarmSpeaker in GameObject.FindGameObjectsWithTag("AlarmSpeaker"))
            {
                alarmSpeaker.GetComponent<AudioSource>().Play();
            }

            StartCoroutine(openExitDoor());
        }
    }

    private IEnumerator alarmFlash(Animator lightObjectAnim)
    {
        yield return new WaitForSeconds(1);
        lightObjectAnim.SetBool("HangingLightFlash", true);
        
    }
    
    private IEnumerator openExitDoor()
    {
        yield return new WaitForSeconds(10);
        GameObject.FindGameObjectWithTag("ExitDoor").GetComponent<Animator>().SetTrigger("OpenExit");
        
    }
}
