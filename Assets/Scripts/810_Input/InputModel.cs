using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class InputModel{

  [SerializeField]
  private IInputMode _mode;
  [SerializeField]
  private int test = 100;
  public IInputMode Mode{ get; set; }

  public InputModel(IInputMode mode)
  {
    Log.Info("InputModel / InputModel Constructor", 1);
    _mode = mode;
  }


}
