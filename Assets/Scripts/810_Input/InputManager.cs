using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputManager : IManager
{
  // ID property
  string ID { get; set; }
  // Name property
  string Name { get; set; }
  // Active status property
  bool IsActive { get; set; }
  // Input System ActionMap Instance
  InputActions InputActions { get; set; }

}
public class InputManager : MonoBehaviour, IInputManager
{
  // ID
   private string _id;
   public string ID
   {
       get => _id;
       set => _id = value; // Implement setter
   }

   // Manager Name
   private string _name;
   public string Name
   {
       get => _name;
       set => _name = value; // Implement setter
   }

   // Activity Status
   private bool _isActive;
   public bool IsActive
   {
       get => _isActive;
       set => _isActive = value; // Implement setter
   }

   // Input System
   private InputActions _inputActions;
   public InputActions InputActions
   {
       get => _inputActions;
       set => _inputActions = value; // Implement setter
   }





   public void Initialize()
   {
       // Initialization logic
      Log.Info("InputManager Initialize()");
   }

   public void Start()
   {
       // Start logic
       Log.Info("InputManager Start()");
   }

   public void Update()
   {
       // Update logic

   }
}
