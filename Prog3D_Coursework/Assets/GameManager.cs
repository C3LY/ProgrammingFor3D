using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    
    [CanBeNull]
    public static GameManager Instance
    {
        get { return _instance; }
    }

    private bool keyboxComplete = false;
    private bool systemsRoomsComplete = false;
    private bool hackSystemsComplete = false;
    private bool playerPassedPoint = false;
    private bool alarmSet = false;
    public bool KeyboxComplete
    {
        get => keyboxComplete;
        set => keyboxComplete = value;
    }

    public bool SystemsRoomsComplete
    {
        get => systemsRoomsComplete;
        set => systemsRoomsComplete = value;
    }

    public bool HackSystemsComplete
    {
        get => hackSystemsComplete;
        set => hackSystemsComplete = value;
    }

    public bool AlarmSet
    {
        get => alarmSet;
        set => alarmSet = value;
    }

    public bool PlayerPassedPoint
    {
        get => playerPassedPoint;
        set => playerPassedPoint = value;
    }
    
    // Start is called before the first frame update
    private void Awake()
    { 
        _instance = this;
    }

    [SerializeField] private GameObject player;

    public GameObject Player
    {
        get => player;
        set => player = value;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
