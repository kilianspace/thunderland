using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopState : IState
{
    private StateContext _context;
   private InputJunction _inputJunction;


    public void SetContext(StateContext context)
    {
        _context = context;
    }

    public IEnumerator Run()
    {
        Debug.Log("ショップを開く...");

        GameInputs gameInputs = new GameInputs(); // Your GameInputs implementation
         InputAction inputAction = gameInputs.SELECT.Up;
         GameState gameState = GameState.TitleMenu_Top;

         _inputJunction = new InputJunction(gameInputs, inputAction, gameState);

         // Register callbacks for the current game state
         _inputJunction.RegisterCallbacksForGameState();

        yield return null; // ショップ状態が1フレーム実行されることを示す
    }

    public IEnumerator PerformFrame()
    {
        // フィールド状態の更新処理
        Log.LogState(this.GetType());
        yield return null; // 更新処理を1フレーム実行
    }

    public void WillExit()
    {

        // Unregister callbacks when the object is destroyed
        _inputJunction.UnregisterCallbacksForGameState();
        Debug.Log("ショップ状態から離れる...");
    }

    public bool ShouldTransition(out IState nextState)
    {
        nextState = null; // 初期値をnullに設定

        if (Input.GetKeyDown(KeyCode.S))
        {
            nextState = new ShopState(); // ShopStateに遷移
            Debug.Log("Sキーが押されたため、ShopStateに遷移します。");
        }
        else if(Input.GetKeyDown(KeyCode.B)){
            nextState = new BattleState(); // ShopStateに遷移
            Debug.Log("Bキーが押されたため、BattleStateに遷移します。");
        }
        else if(Input.GetKeyDown(KeyCode.F)){
            nextState = new FieldState(); // ShopStateに遷移
            Debug.Log("Fキーが押されたため、FieldStateに遷移します。");
        }

        // 次の状態が設定されたかどうかを返す
        return nextState != null;
    }


}