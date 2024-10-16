using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseModule<T> : MonoBehaviour, IModule<T>
{
    [SerializeField]
    protected IManager _manager;

    // Implementation
    public ICommunicator<T> Communicator { get; set; }
    public IManager Manager => _manager;

    // Awake for initialization
    protected virtual void Awake()
    {
        Communicator = CreateCommunicator();
        Log.Info("BaseModule<T> / Awake()");
    }

    // Needs to be implemented in the child classes
    protected abstract ICommunicator<T> CreateCommunicator();

    public IManager GetManager()
    {
        return _manager;
    }

    // Public method to set the manager after instantiation
    public void SetManager(IManager manager)
    {
        _manager = manager;
    }
}
