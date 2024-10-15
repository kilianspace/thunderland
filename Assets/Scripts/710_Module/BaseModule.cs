using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseModule<T> : MonoBehaviour, IModule<T>
{

    [SerializeField]
    protected IManager _manager;

    //Implementation
    public ICommunicator<T> Communicator { get; set; }
    public IManager Manager => _manager;

    protected BaseModule(IManager  manager)
    {
      _manager = manager;
      Log.Object(manager);
      Log.Info("BaseModule Constructor");
    }

    // Neeeds to be implemented in the child classes
    protected abstract ICommunicator<T> CreateCommunicator();

    protected virtual void Awake()
     {
         Communicator = CreateCommunicator();
         Log.Info("BaseModule<T> / Awake()");
     }

    public IManager GetManager()
    {
      return _manager;
    }


}
