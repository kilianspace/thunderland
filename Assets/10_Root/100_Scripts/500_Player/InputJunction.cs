using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputJunction
{
   private GameInputs _inputs;
   private InputAction _inputAction;
   private GameState _gameState;

   private class InputActionEnsemble
   {
      private GameInputs _gameInputs;
      private Dictionary<InputAction, KeyActionBinder> _ensemble;

      public InputActionEnsemble(GameInputs gameInputs)
      {
         _ensemble = new Dictionary<InputAction, KeyActionBinder>();
         _gameInputs = gameInputs;
      }

      public void AddKeyActionBinderWithInputAction(InputAction inputAction, KeyActionBinder binder)
      {
         _ensemble.Add(inputAction, binder);
      }

      public KeyActionBinder GetBinder(InputAction inputAction)
      {
         if (_ensemble.TryGetValue(inputAction, out KeyActionBinder binder))
         {
            return binder;
         }
         return null;
      }
   }

   private class KeyActionBinder
   {
      private GameInputs _gameInputs;
      private GameState _gameState;
      private Dictionary<ControllerKey, Action<InputAction.CallbackContext>> _ensemble;

      public KeyActionBinder(GameInputs gameInputs, GameState gameState)
      {
         _gameInputs = gameInputs;
         _gameState = gameState;
         _ensemble = new Dictionary<ControllerKey, Action<InputAction.CallbackContext>>();
      }

      public void AddCallback(ControllerKey controllerKey, Action<InputAction.CallbackContext> inputAction)
      {
         _ensemble.Add(controllerKey, inputAction);
      }

      public Action<InputAction.CallbackContext> GetCallback(ControllerKey controllerKey)
      {
         _ensemble.TryGetValue(controllerKey, out Action<InputAction.CallbackContext> callback);
         return callback;
      }
   }

   private InputActionEnsemble _ensemble;
   private KeyActionBinder _binder;

   public InputJunction(
      GameInputs inputs,
      InputAction inputAction,
      GameState gameState,
      // Face Buttons
      ControllerKey? cross = null,
      ControllerKey? circle = null,
      ControllerKey? square = null,
      ControllerKey? triangle = null,
      // D-Pad
      ControllerKey? dPadUp = null,
      ControllerKey? dPadDown = null,
      ControllerKey? dPadLeft = null,
      ControllerKey? dPadRight = null,
      // Shoulder Buttons
      ControllerKey? l1 = null,
      ControllerKey? r1 = null,
      // Triggers
      ControllerKey? l2 = null,
      ControllerKey? r2 = null,
      // Joysticks
      ControllerKey? leftStickX = null,
      ControllerKey? leftStickY = null,
      ControllerKey? rightStickX = null,
      ControllerKey? rightStickY = null,
      // Joystick Press
      ControllerKey? leftStickPress = null,
      ControllerKey? rightStickPress = null,
      // Touchpad
      ControllerKey? touchpadClick = null,
      // Options and Share Buttons
      ControllerKey? options = null,
      ControllerKey? share = null,
      // PlayStation Button
      ControllerKey? psButton = null,
      // Touchpad and Motion Sensor (if needed)
      ControllerKey? touchpadSwipeUp = null,
      ControllerKey? touchpadSwipeDown = null,
      ControllerKey? touchpadSwipeLeft = null,
      ControllerKey? touchpadSwipeRight = null,
      // Gyroscope/Motion Sensor
      ControllerKey? gyro = null,
      ControllerKey? accelerometer = null
   )
   {
      _inputs = inputs;
      _inputAction = inputAction;
      _gameState = gameState;

      // Create new instances
      _ensemble = new InputActionEnsemble(_inputs);
      _binder = new KeyActionBinder(_inputs, _gameState);

      // Bind callbacks to the KeyActionBinder
      if (cross.HasValue)
      {
         _binder.AddCallback(cross.Value, OnCrossPressed);
      }

      // Register other callbacks here as needed...

      // Add the KeyActionBinder to the InputActionEnsemble
      _ensemble.AddKeyActionBinderWithInputAction(_inputAction, _binder);
   }

   private void OnCrossPressed(InputAction.CallbackContext context)
   {
      Debug.Log("Cross button pressed");
   }

   public void RegisterCallbacksForGameState()
   {
      KeyActionBinder binder = _ensemble.GetBinder(_inputAction);
      if (binder != null)
      {
         // Register your input actions here based on the game state
         Action<InputAction.CallbackContext> crossCallback = binder.GetCallback(ControllerKey.Cross);
         if (crossCallback != null)
         {
            _inputs.SELECT.Cross.performed += crossCallback;
         }
         // Register other actions...
      }
   }

   public void UnregisterCallbacksForGameState()
   {
      KeyActionBinder binder = _ensemble.GetBinder(_inputAction);
      if (binder != null)
      {
         // Unregister your input actions here based on the game state
         Action<InputAction.CallbackContext> crossCallback = binder.GetCallback(ControllerKey.Cross);
         if (crossCallback != null)
         {
            _inputs.SELECT.Cross.performed -= crossCallback;
         }
         // Unregister other actions...
      }
   }
}
