using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndComputer : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private GameObject hackingSystemUI;
    [SerializeField] private GameObject completeUI;
    [SerializeField] private GameObject StrikeUI;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hackingSystemUI.SetActive(true);
                StartCoroutine(finishedHacking());
            }
        }
    }

    private IEnumerator finishedHacking()
    {
        yield return new WaitForSeconds(5);
        
        hackingSystemUI.SetActive(false);
        completeUI.SetActive(true);
        completeUI.GetComponent<Animator>().SetTrigger("Complete");
        StrikeUI.SetActive(true);
        audioSource.Play();
    }
}
