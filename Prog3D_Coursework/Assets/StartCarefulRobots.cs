using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartCarefulRobots : MonoBehaviour
{
 [SerializeField] private UnityEvent voiceCallEvent;

 private void onTriggerStay(Collider other)
 {
     if (other.CompareTag("Player") && !GameManager.Instance.AlarmSet)
     {
         voiceCallEvent.Invoke();
     }
 }
}
