using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class InputModule : BaseModule<InputPayload>
{

  // Inspector fields to observe
  [SerializeField]
  private InputCommunicator _inputCommunicator;
  [SerializeField]
  private IManager _managerInspectorView;


  protected override void Awake()
  {

    // ++++++++++++++++++++++++ //
    Log.Info("InputModule/ Awake()", 1);
    // ++++++++++++++++++++++++ //

    base.Awake();
    SetupManager();

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
         GameObject childObject = new GameObject("InputManager");
         childObject.transform.parent = this.transform;
         if (childObject.GetComponent<InputManager>() == null)
         {
             childObject.AddComponent<InputManager>();
         }
     }
  }
  ///////////////////////////////



  // Implement CreateCommunicator method
  protected override ICommunicator<InputPayload> CreateCommunicator()
  {
      Log.Info("InputModule / CreateCommunicator()", 1);

      _inputCommunicator = new InputCommunicator();

      return _inputCommunicator;
  }

  // Optional: Use SetManager to assign manager after instantiation
  public void AssignManager(IManager manager)
  {
      SetManager(manager); // Use the method from BaseModule
  }


}
