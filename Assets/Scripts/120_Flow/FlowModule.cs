using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class FlowModule : BaseModule<Payload<object>>
{

    // Manager
    ///////////////////////////////////
    [SerializeField] private FlowManager _flowManager;
    ///////////////////////////////////


    // Communicator
    ///////////////////////////////////
    [SerializeField] private FlowCommunicator _flowCommunicator;
    public FlowCommunicator FlowCommunicator
    {
        get { return _flowCommunicator; }
        set { _flowCommunicator = value; }
    }
    ///////////////////////////////////

    protected override void Awake()
    {
        Log.Info("FlowModule => Awake()", 1);
        base.Awake();
        SetupManager();

      _flowCommunicator = new FlowCommunicator();
    }


  // Setup Manager
  ///////////////////////////////
  private void SetupManager(){
    Log.Info("FlowModule => SetupManager()", 1);
     // Add InputManager as a component
     if (_flowManager == null)
     {
         GameObject childObject = new GameObject("FlowManager");
         childObject.transform.parent = this.transform;
         if (childObject.GetComponent<FlowManager>() == null)
         {
             _flowManager = childObject.AddComponent<FlowManager>();
         }
     }
  }
  ///////////////////////////////



}
