using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{

    private protected GameObject slotPosition;
    private void Start()
    {
        slotPosition = GameObject.Find("PickUpSlot");
    }

    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().freezeRotation = true;
                GetComponent<Rigidbody>().isKinematic = true;
                this.transform.position = slotPosition.GetComponent<Transform>().position;
                this.transform.parent = slotPosition.transform;
            }
        }
    }

    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().enabled = true;
    }
}
