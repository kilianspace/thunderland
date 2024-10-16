using System;
using UnityEngine;
using UnityEngine.InputSystem;


[System.Serializable]
public class VerticalSelectionInputMode : IInputMode
{
    private PlayerInput _playerInput;

    public event Action<InputAction.CallbackContext> JoystickMove_L;
    public event Action<InputAction.CallbackContext> JoystickMove_R;
    public event Action<InputAction.CallbackContext> JoystickClick_L;
    public event Action<InputAction.CallbackContext> JoystickClick_R;

    public event Action<InputAction.CallbackContext> L1;
    public event Action<InputAction.CallbackContext> R1;
    public event Action<InputAction.CallbackContext> L2;
    public event Action<InputAction.CallbackContext> R2;

    public event Action<InputAction.CallbackContext> Triangle;
    public event Action<InputAction.CallbackContext> Square;
    public event Action<InputAction.CallbackContext> Circle;
    public event Action<InputAction.CallbackContext> Cross;


    public event Action<InputAction.CallbackContext> Up;
    public event Action<InputAction.CallbackContext> Down;
    public event Action<InputAction.CallbackContext> Left;
    public event Action<InputAction.CallbackContext> Right;



    // Circle button
    /////////////////////////////////////////////////////
    private void OnCircle(InputAction.CallbackContext context)
    {
        Circle?.Invoke(context);
        Log.Object(context, 1);
    }
    /////////////////////////////////////////////////////


    // UP button
    /////////////////////////////////////////////////////
    private void OnUp(InputAction.CallbackContext context)
    {
        Up?.Invoke(context);
        Log.Object(context, 1);
    }
    /////////////////////////////////////////////////////

    // DOWN button
    /////////////////////////////////////////////////////
    private void OnDown(InputAction.CallbackContext context)
    {
        Down?.Invoke(context);
        Log.Object(context, 1);
    }
    /////////////////////////////////////////////////////



    public VerticalSelectionInputMode(PlayerInput playerInput)
    {
        _playerInput = playerInput; // Initialize PlayerInput

        // Enter
        _playerInput.VERTICAL_SELECTION.ENTER.started += OnCircle;
        _playerInput.VERTICAL_SELECTION.ENTER.performed += OnCircle;
        _playerInput.VERTICAL_SELECTION.ENTER.canceled += OnCircle;

        // Up
        _playerInput.VERTICAL_SELECTION.UP.started += OnUp;
        _playerInput.VERTICAL_SELECTION.UP.performed += OnUp;
        _playerInput.VERTICAL_SELECTION.UP.canceled += OnUp;

        //
        _playerInput.VERTICAL_SELECTION.DOWN.started += OnDown;
        _playerInput.VERTICAL_SELECTION.DOWN.performed += OnDown;
        _playerInput.VERTICAL_SELECTION.DOWN.canceled += OnDown;
    }


}
