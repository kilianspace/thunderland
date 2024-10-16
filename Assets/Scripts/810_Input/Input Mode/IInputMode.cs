using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public interface IInputMode
{

    event Action<InputAction.CallbackContext> JoystickMove_L;
    event Action<InputAction.CallbackContext> JoystickMove_R;
    event Action<InputAction.CallbackContext> JoystickClick_L;
    event Action<InputAction.CallbackContext> JoystickClick_R;

    event Action<InputAction.CallbackContext> L1;
    event Action<InputAction.CallbackContext> R1;
    event Action<InputAction.CallbackContext> L2;
    event Action<InputAction.CallbackContext> R2;

    event Action<InputAction.CallbackContext> Triangle;
    event Action<InputAction.CallbackContext> Square;
    event Action<InputAction.CallbackContext> Circle;
    event Action<InputAction.CallbackContext> Cross;

    event Action<InputAction.CallbackContext> Up;
    event Action<InputAction.CallbackContext> Down;



}
