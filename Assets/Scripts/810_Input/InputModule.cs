using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class InputModule : BaseModule<Payload<object>>
{

    // Manager
    ///////////////////////////////////
    [SerializeField] private InputManager _inputManager;
    ///////////////////////////////////

    // Communicator
    ///////////////////////////////////
    [SerializeField] private InputCommunicator _inputCommunicator;
    public InputCommunicator InputCommunicator
    {
        get { return _inputCommunicator; }
        set { _inputCommunicator = value; }
    }
    ///////////////////////////////////

    protected override void Awake()
    {
        Log.Info("InputModule/ Awake()", 1);
        base.Awake();
        SetupManager();

        _inputCommunicator = new InputCommunicator();
    }


    // Setup Manager
    ///////////////////////////////
    private void SetupManager()
    {
        Log.Info("InputModule => SetupManager()", 1);
        // Add InputManager as a component
        if (_inputManager == null)
        {
            GameObject childObject = new GameObject("InputManager");
            childObject.transform.parent = this.transform;
            if (childObject.GetComponent<InputManager>() == null)
            {
                _inputManager = childObject.AddComponent<InputManager>();
            }
        }
    }
    ///////////////////////////////




}
