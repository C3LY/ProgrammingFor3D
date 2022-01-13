using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Grenade : PickUpItem
{
    private AudioSource audioSourceGrenade;
    private float throwPower = 1.5f;
    private float force = 2f;
    private float radius = 10;

    [SerializeField] private GameObject explosionEffect;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("mouse key is G");
            this.transform.parent = null; // releases the object from being in a child of the slotPosition
            GetComponent<Rigidbody>().freezeRotation = false; //when the object is being held, the rotation is frozen (less distracting), so when it is releaed this is turned back on. 
            GetComponent<Rigidbody>().useGravity = true; //object will have gravity 
            GetComponent<Rigidbody>().isKinematic = false; //object will now collide with other objects and force can be applied to it
            GetComponent<Rigidbody>()
                .AddForce(
                    new Vector3(Camera.main.transform.forward.x, 0.2f, Camera.main.transform.forward.z) * throwPower,
                    ForceMode.Impulse); //Adds force in direction where camera is looking with 'throwpower' power and Impulse forcemode
            GetComponent<Collider>().enabled = true;  //enable collider of the object so it can bounce
            StartCoroutine(explode());
        }
    }

    private IEnumerator explode()
    {
        yield return new WaitForSeconds(2);  //delays explosion a bit
        Instantiate(explosionEffect, transform.position, transform.rotation); //explosion prefab is instantiated
        Debug.Log("Exploded");
        audioSourceGrenade = GetComponent<AudioSource>();
        audioSourceGrenade.PlayOneShot(audioSourceGrenade.clip, 1f); // bang sound!
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, radius); // tracks all objects within a certain range
        foreach (Collider objectCollider in objectsInRange)
        {
            if (objectCollider.CompareTag("Enemy") || objectCollider.CompareTag("GroundProps")) // if object is an enemy or groundprop it can be destory (therefore not the floor is destroyed)
            {
                Destroy(objectCollider.gameObject); // destroy object
            }
        } 
        Destroy(gameObject);
    }
    
}
