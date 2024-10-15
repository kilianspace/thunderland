using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InputModel{

  public event Action<InputAction.CallbackContext> WhatUpDoes;
  void OnUp(InputAction.CallbackContext context){
    WhatUpDoes?.Invoke(context);
  }

  public InputModel()
  {
    Log.Info("InputModel / InputModel Constructor", 1);
  }


}
