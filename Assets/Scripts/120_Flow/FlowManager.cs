using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FlowManager : MonoBehaviour
{

  // Singleton
  public static FlowManager Instance { get; private set; }


  // Nestedd Class to store flow context data
  /////////////////////////////////////////////
  [System.Serializable]// Show FlowContext in Inspector
  public class FlowContext
  {
    // Show the CurrentState in the Inspector
    public GameState CurrentState;
  }
  [SerializeField]// Show FlowContext in Inspector
  private FlowContext _flowContext;
  /////////////////////////////////////////////

  private void Awake()
  {

    // Mainly in a case of entering a new scene
    if( Instance != null && Instance != this )
    {
      Destroy(this.gameObject);
      Debug.Log("FlowManager gameobject has got deleted");
      return;
    }

    // Set this as the only one
    Instance = this;
    Debug.Log("A new FlowManager has got created");
    DontDestroyOnLoad(this.gameObject);


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
