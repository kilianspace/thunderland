using System.Collections;
using UnityEngine;

public class TitleMenuSceneSetupState : IState
{
    private StateContext _context;

    public StateContext GetContext() // 実装
    {
        return _context;
    }

    public void SetContext(StateContext context)
    {
        _context = context;
    }

    public IEnumerator Run()
    {
        Debug.Log("TitleMenuSceneSetupStateです。。。。");


        yield return new WaitForSeconds(4); // 3秒待機
    }

    public IEnumerator PerformFrame()
    {
        // フィールド状態の更新処理
        Log.LogState(this.GetType());

        yield return null; // 更新処理を1フレーム実行
    }

    public void WillExit()
    {
        Debug.Log("SceneSetupSstateを離脱します");
    }

    public bool ShouldTransition(out IState nextState)
    {
        nextState = null; // 初期値をnullに設定

         nextState = new TitleMenuTopState();

        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     nextState = new ShopState(); // ShopStateに遷移
        //     Debug.Log("Sキーが押されたため、ShopStateに遷移します。");
        // }
        // else if(Input.GetKeyDown(KeyCode.B)){
        //     nextState = new BattleState(); // ShopStateに遷移
        //     Debug.Log("Bキーが押されたため、BattleStateに遷移します。");
        // }
        // else if(Input.GetKeyDown(KeyCode.F)){
        //     nextState = new FieldState(); // ShopStateに遷移
        //     Debug.Log("Fキーが押されたため、FieldStateに遷移します。");
        // }

        // 次の状態が設定されたかどうかを返す
        return nextState != null;
    }

}
