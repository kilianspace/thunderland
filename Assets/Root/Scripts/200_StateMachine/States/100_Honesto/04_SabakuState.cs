using System.Collections;
using UnityEngine;

// Sabakuの状態を管理するクラス
public class SabakuState : IState
{
    private Statemachine _machine; // ステートマシンの参照
    private UIManager _uiManager; // UIManagerの参照

    // コンストラクタ
    public SabakuState(Statemachine machine, UIManager uiManager)
    {
        _machine = machine; // HonestoStatemachine を参照
        _uiManager = uiManager; // UIManager を参照
    }

    // 状態のプレイ処理
    public IEnumerator Play(Context context)
    {
        Debug.Log("もう限界だと声を出せば");
        yield return new WaitForSeconds(1f); // 1秒待機
    }

    // 更新処理
    public IEnumerator Update(Context context)
    {
        yield return null; // 更新処理がない場合はnullを返す
    }

    // 状態終了処理
    public void Exit()
    {
        Debug.Log("次の新しい場面が");
    }
}
