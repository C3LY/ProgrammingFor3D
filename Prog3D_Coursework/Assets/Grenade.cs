using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grenade : PickUpItem
{
    private AudioSource audioSourceGrenade;
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
        audioSourceGrenade = GetComponent<AudioSource>();
        audioSourceGrenade.PlayOneShot(audioSourceGrenade.clip, 1f);
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, 10);
        foreach (Collider objectCollider in objectsInRange)
        {
            if (objectCollider.gameObject.tag == "Enemy" || objectCollider.gameObject.tag == "GroundProps")
            {
                Destroy(objectCollider.gameObject);
            }
        } 
    }
    
}
