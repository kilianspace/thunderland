using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class CoreModule : BaseModule<Payload<object>>
{

    // Manager
    ///////////////////////////////////
    [SerializeField] private CoreManager _coreManager;
    ///////////////////////////////////

    // Communicator
    ///////////////////////////////////
    [SerializeField] private CoreCommunicator _coreCommunicator;
    public CoreCommunicator CoreCommunicator
    {
        get { return _coreCommunicator; }
        set { _coreCommunicator = value; }
    }
    ///////////////////////////////////


    protected override void Awake()
    {
        Log.Info("CoreModule => Awake()", 1);
        base.Awake();
        SetupManager();


        _coreCommunicator = new CoreCommunicator();
    }

    private void SetupManager()
    {
        Log.Info("CoreModule => SetupManager()", 1);
        if (_coreManager == null)
        {
            GameObject childObject = new GameObject("CoreManager");
            childObject.transform.parent = this.transform;
            // Generate a new CoreManager instance by using AddComponent
            _coreManager = childObject.AddComponent<CoreManager>();
        }
    }




}
