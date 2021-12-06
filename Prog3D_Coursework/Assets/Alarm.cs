using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.KeyboxComplete && GameManager.Instance.AlarmSet==false)
        {
            GameManager.Instance.AlarmSet = true;
            _audioSource.Play();
            foreach(GameObject lightObject in GameObject.FindGameObjectsWithTag("HangingLight"))
            {
              //  if(lightObject.name == "Hanging Point Light")
              //  {
                    Animator lightObjectAnim = lightObject.GetComponent<Animator>();
                    lightObjectAnim.SetBool("HangingLightStart", true);
                    StartCoroutine(alarmFlash(lightObjectAnim));
              //  }
            }
            
            foreach(GameObject alarmSpeaker in GameObject.FindGameObjectsWithTag("AlarmSpeaker"))
            {
                alarmSpeaker.GetComponent<AudioSource>().Play();
            }
        }
    }

    private IEnumerator alarmFlash(Animator lightObjectAnim)
    {
        yield return new WaitForSeconds(1);
        lightObjectAnim.SetBool("HangingLightFlash", true);
    }
}
