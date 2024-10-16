using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


  [System.Serializable]
public class FlowCoordinator
{


    // Nestedd Class to store flow context data
    /////////////////////////////////////////////
    [System.Serializable]// Show FlowContext in Inspector
    public class FlowContext
    {
      // Show the CurrentState in the Inspector
      public IPhase CurrentPhase;
    }
    [SerializeField]// Show FlowContext in Inspector
    private FlowContext _flowContext;
    /////////////////////////////////////////////

    public IPhase CurrentPhase;

    public void IgniteFlow(){
      Log.Info("FlowCoordinator => StartFlow", 1);
      _flowContext = new FlowContext();
      _flowContext.CurrentPhase = new TitleMenuPhase(); // 初期フェーズを設定
      _flowContext.CurrentPhase.State = GameState.TitleMenu_Top; // Set initial state
    }

    // Method to change the state
    public void ChangeState(GameState newState)
    {
        _flowContext.CurrentPhase.State = newState; // Update current state
        Debug.Log($"State changed to: {_flowContext.CurrentPhase.State}");
    }


}
