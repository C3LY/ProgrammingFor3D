using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenStartDoor : MonoBehaviour
{
    private Animator anim;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip openDoorClip;
    [SerializeField] private AudioClip closeDoorClip;
    private void Start()
    {
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _audioSource.clip = openDoorClip;
                _audioSource.Play();
                StartCoroutine(animateDoor());
            }
        }
    }

    private IEnumerator animateDoor()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("animating start door");
        anim.SetBool("DoorOpen",  true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")&& anim.GetBool("DoorOpen"))
        {
            anim.SetBool("DoorOpen",  false);
            _audioSource.clip = closeDoorClip;
            _audioSource.Play();

//            StartCoroutine(animateDoorClose());
        }
    }
    
    private IEnumerator animateDoorClose()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("animating start door");


    }

}
