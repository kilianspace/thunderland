using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseModule<T> : MonoBehaviour, IModule<T>
{

    // Implementation
    public ICommunicator<T> Communicator { get; set; }


    // Awake for initialization
    protected virtual void Awake()
    {

    }

}
