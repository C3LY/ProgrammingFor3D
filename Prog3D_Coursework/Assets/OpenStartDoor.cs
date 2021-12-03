using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStartDoor : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("animating start door");
                anim.SetTrigger("DoorOpen");
            }
        }
    }
}
