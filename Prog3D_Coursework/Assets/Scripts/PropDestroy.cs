using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PropDestroy : MonoBehaviour
{
    [SerializeField] private GameObject[] lootDrop;
    [SerializeField] private GameObject explosion;
//    [SerializeField] private UnityEvent voiceCallEvent;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(lootDrop.Length > 0){

                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject newObject = GameObject.Instantiate(lootDrop[Random.Range(0,lootDrop.Length-1)]);
                    newObject.transform.SetParent(gameObject.transform.parent);
                    newObject.transform.localPosition = gameObject.transform.localPosition;
                    GameObject newExplosion = GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
                    newExplosion.transform.parent = gameObject.transform.parent;
                    newExplosion.GetComponentInChildren<ParticleSystem>().Play();
                    Destroy(gameObject);
                }
            }
        }
    }
}
