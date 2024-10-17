using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[System.Serializable]
public class InputManager : MonoBehaviour
{

    /// Input System
    ///////////////////////////////////////
    private static PlayerInput _playerInput;
    ///////////////////////////////////////


    /// Current Input Mode
    ///////////////////////////////////////
    [SerializeField]
    private IInputMode _currentInpuMode;
    ///////////////////////////////////////



    // Stored Module Instances
    ///////////////////////////////////
    [SerializeField] private InputModule _inputModule;
    ///////////////////////////////////




    // Context
    //////////////////////////////////////
    [SerializeField]
    private InputContext _inputContext;
    ///////////////////////////////////////



    /// Input Obserevr
    ///////////////////////////////////////
    //  [SerializeField]
    //  private IInputMode _currentInpuMode;
    ///////////////////////////////////////



    public void Awake(){
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        Log.Object( _playerInput, 1 );


        ///////////////////////////////////
        _inputContext = new InputContext();
        ///////////////////////////////////

    }

    public void Start()
    {
        // Start logic
        Log.Info("InputManager Start()",1);


        IInputMode inputMode =  new VerticalSelectionInputMode(_playerInput);
        InputModel model =  new InputModel(inputMode);
        _currentInpuMode = inputMode;
    }






}
