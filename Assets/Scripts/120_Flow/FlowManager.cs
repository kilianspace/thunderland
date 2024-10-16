using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FlowManager : MonoBehaviour
{

  // Nestedd Class to store flow context data
  /////////////////////////////////////////////
  public class FlowContext
  {
    public GameState CurrentState { get; set; } // Current game state
  }
  private FlowContext _flowContext;
  /////////////////////////////////////////////

  private void Awake()
  {
      _flowContext = new FlowContext();
      _flowContext.CurrentState = GameState.TitleMenu_Top; // Set initial state
  }

  // Method to change the state
  public void ChangeState(GameState newState)
  {
      _flowContext.CurrentState = newState; // Update current state
      Debug.Log($"State changed to: {_flowContext.CurrentState}");
  }
}
