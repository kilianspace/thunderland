using UnityEngine;

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


  protected void Awake()
  {
    // Write here when you need something to be initialized
    _inputCommunicator = new InputCommunicator();
    // BaseModule Property
    Communicator = _inputCommunicator;

   // BaseModule の _manager を設定
    _managerInspectorView = _manager;
    // InputManager を子オブジェクトとして追加
    if (_managerInspectorView == null)
    {
        _managerInspectorView = gameObject.AddComponent<InputManager>();
    }

  }

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
