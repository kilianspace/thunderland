using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class FlowManager : MonoBehaviour
{

    // Singleton
    public static FlowManager Instance { get; private set; }

    // Flow Controll
    [SerializeField]
    private FlowCoordinator _flowCoordinator;

    // Context
    //////////////////////////////////////
    [SerializeField]
    private FlowContext _flowContext;
    //////////////////////////////////////

    private void Awake()
    {

        // Singleton Pattern
        ////////////////////////////////////////////
        if( Instance != null && Instance != this )
        {
        Destroy(this.gameObject);
        Debug.Log("FlowManager gameobject has got deleted");
        return;
        }
        // Set this as the only one
        Instance = this;
        Debug.Log("A new FlowManager has got created");
        DontDestroyOnLoad(this.gameObject);
        ////////////////////////////////////////////


        // Initialize Context
        ////////////////////////////////////////////
        _flowContext = new FlowContext();
        ////////////////////////////////////////////



        // Flow Controller
        ////////////////
        _flowCoordinator = new FlowCoordinator();
        _flowCoordinator.IgniteFlow();
        ////////////////


    }

}
