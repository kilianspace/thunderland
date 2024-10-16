using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputManager : IManager
{


}
[System.Serializable]
public class InputManager : MonoBehaviour, IInputManager
{

  /// Input System
  ///////////////////////////////////////
  private static PlayerInput _playerInput;
  ///////////////////////////////////////

  /// Payload
  ///////////////////////////////////////
  [SerializeField]
  private InputPayload _inputPayload;
  ///////////////////////////////////////


  /// Current Input Mode
  ///////////////////////////////////////
  [SerializeField]
  private IInputMode _currentInpuMode;
  ///////////////////////////////////////


  /// Input Obserevr
  ///////////////////////////////////////
  [SerializeField]
//  private IInputMode _currentInpuMode;
  ///////////////////////////////////////



   public void Initialize()
   {
       // Initialization logic
      Log.Info("InputManager Initialize()");
   }


   public void Awake(){
     _playerInput = new PlayerInput();
      _playerInput.Enable();
     Log.Object( _playerInput, 1 );
   }

   public void Start()
   {
       // Start logic
       Log.Info("InputManager Start()",1);


       IInputMode inputMode =  new VerticalSelectionInputMode(_playerInput);
       InputModel model =  new InputModel(inputMode);
       _inputPayload = new InputPayload(model);


       _currentInpuMode = inputMode;
   }

   public void Update()
   {
       // Update logic
   }
}
