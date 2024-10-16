using UnityEngine;
using UnityEngine.InputSystem;

public class InputModule : BaseModule<InputPayload>
{

  // Inspector fields to observe
  [SerializeField]
  private InputCommunicator _inputCommunicator;
  [SerializeField]
  private IManager _managerInspectorView;

  // Pass over "manager" using Constructor of BaseModule
  public InputModule(IManager manager) : base(manager){
  }


  protected override void Awake()
  {

    // ++++++++++++++++++++++++ //
    Log.Info("InputModule/ Awake()", 1);
    // ++++++++++++++++++++++++ //

    // 1
    InitializeCommunicator();
    // 2
    SetupManager();
    // 3
    base.Awake();

  }


  // Setup Manager
  ///////////////////////////////
  private void SetupManager(){

    // ++++++++++++++++++++++++ //
    Log.Class(this);
    // ++++++++++++++++++++++++ //

    // Setup _manager of BaseModule
     _managerInspectorView = _manager;
     // Add InputManager as a component
     if (_managerInspectorView == null)
     {
         _managerInspectorView = gameObject.AddComponent<InputManager>();
     }
  }
  ///////////////////////////////



  // Initialize InputCommunicator
  ///////////////////////////////
  private void InitializeCommunicator(){

    Log.Info("InputModule/ InitializeCommunicator()", 1);

    // Write here when you need something to be initialized
    _inputCommunicator = new InputCommunicator();
    InputModel inputModel = new InputModel();
    InputPayload payload = new InputPayload(inputModel);
    _inputCommunicator.Payload = payload;

    // BaseModule Property
    Communicator = _inputCommunicator;

  }
  ///////////////////////////////



  protected override ICommunicator<InputPayload> CreateCommunicator()
  {
      return new InputCommunicator();
  }

  public void ProcessInput(InputPayload inputPayload)
 {
     _inputCommunicator.Transmit(inputPayload);
 }

   // Debugging purposes: update inspector fields on every frame if needed
  private void Update()
  {
      // Make sure the inspector fields always show the latest values
      _managerInspectorView = _manager;
  }

}
