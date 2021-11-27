using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropDestroy : MonoBehaviour
{
    [SerializeField] private GameObject[] lootDrop;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(lootDrop.Length > 0){

                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject newObject = GameObject.Instantiate(lootDrop[0]);
                    newObject.transform.SetParent(gameObject.transform.parent);
                    newObject.transform.localPosition = gameObject.transform.localPosition;
                    Destroy(gameObject);
                }
            }
    }
    }
}
