using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private Animator animtor;

    [SerializeField] private GameObject missionGoals;

    [SerializeField] private GameObject goal1;

    [SerializeField] private GameObject goal2;

    [SerializeField] private GameObject goal3;

    [SerializeField] private AudioClip dataBeepClip;
    [SerializeField] private AudioClip goalClip;
    
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(IntroRoutine());
    
    }

    private IEnumerator IntroRoutine()
    {
        yield return new WaitForSeconds(20);
        Debug.Log("Animating");
        missionGoals.SetActive(true);
        audioSource.clip = dataBeepClip;
        audioSource.Play();
        missionGoals.GetComponent<Animator>().SetTrigger("GoalsOpen");
        yield return new WaitForSeconds(1);
        goal1.SetActive(true);
        audioSource.clip = goalClip;
        audioSource.Play();
        goal1.GetComponent<Animator>().SetTrigger("Open");
        yield return new WaitForSeconds(2);
        goal2.SetActive(true);
        audioSource.Play();
        goal2.GetComponent<Animator>().SetTrigger("Open");
        yield return new WaitForSeconds(2);
        goal3.SetActive(true);
        audioSource.Play();
        goal3.GetComponent<Animator>().SetTrigger("Open");
    }
    
}
