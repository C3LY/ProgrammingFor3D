using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grenade : PickUpItem
{
    private AudioSource audioSourceGrenade;
    private float force = 2f;
    private float radius = 10;

    [SerializeField] private GameObject explosionEffect;
    private void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().freezeRotation = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(new Vector3(Camera.main.transform.forward.x,0.2f, Camera.main.transform.forward.z) * throwPower, ForceMode.Impulse);    //Adds force in direction where camera is looking with 'throwpower' power and Impulse forcemode
        GetComponent<Collider>().enabled = true;
        StartCoroutine(explode());
    }

    private IEnumerator explode()
    {
        yield return new WaitForSeconds(2);
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Debug.Log("Exploded");
        audioSourceGrenade = GetComponent<AudioSource>();
        audioSourceGrenade.PlayOneShot(audioSourceGrenade.clip, 1f);
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider objectCollider in objectsInRange)
        {
            if (objectCollider.CompareTag("Enemy") || objectCollider.CompareTag("GroundProps"))
            {
                Rigidbody rb = objectCollider.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }
        } 
        Destroy(gameObject);
    }
    
}
