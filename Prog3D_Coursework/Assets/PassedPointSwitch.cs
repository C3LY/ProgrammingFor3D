using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassedPointSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grenade") && GameManager.Instance.AlarmSet)
        {
            GameManager.Instance.PlayerPassedPoint = true;

        }
    }
}
