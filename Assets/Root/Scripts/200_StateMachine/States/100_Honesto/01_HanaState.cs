using System.Collections;
using UnityEngine;

// Hanaの状態を管理するクラス
public class HanaState : IState
{
    private Statemachine _machine; // ステートマシンの参照
    private UIManager _uiManager; // UIManagerの参照

    // コンストラクタ
    public HanaState(Statemachine machine, UIManager uiManager)
    {
        _machine = machine;
        _uiManager = uiManager;
    }

    // 状態のプレイ処理
    public IEnumerator Play(Context context)
    {
        Debug.Log("HanaStateがプレイ中です。");
        yield return null; // 何らかの処理をここに書く
    }

    // 更新処理
    public IEnumerator Update(Context context)
    {
        yield return null; // 更新処理がない場合はnullを返す
    }

    // 状態終了処理
    public void Exit()
    {
        // 必要に応じてクリーンアップ処理
    }
}
