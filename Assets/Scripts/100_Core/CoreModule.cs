using UnityEngine;
using UnityEngine.InputSystem;



[System.Serializable]
public class CoreModule : BaseModule<CorePayload>
{
    [SerializeField]
    private CoreCommunicator _coreCommunicator;
    [SerializeField]
    private IManager _coreManager;

    protected override void Awake()
    {
        // Initialize here
        base.Awake();
        SetupManager();

    }

    private void SetupManager()
    {
        Log.Class(this);
        _coreManager = _manager;

        if (_coreManager == null)
        {
            GameObject childObject = new GameObject("CoreManager");
            childObject.transform.parent = this.transform;
            if (childObject.GetComponent<CoreManager>() == null)
            {
                childObject.AddComponent<CoreManager>();
            }
        }
    }

    protected override ICommunicator<CorePayload> CreateCommunicator()
    {
        Log.Info("CoreModule / CreateCommunicator()", 1);
        _coreCommunicator = new CoreCommunicator();
        CoreContext context = new CoreContext();
        CorePayload payload = new CorePayload(context);
        _coreCommunicator.Payload = payload;

        return _coreCommunicator;
    }
}
