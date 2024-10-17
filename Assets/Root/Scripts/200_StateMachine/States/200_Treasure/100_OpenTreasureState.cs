using System.Collections;
using UnityEngine;

// 宝箱を開く状態を管理するクラス
public class OpenTreasureState : IState
{
    private Statemachine _machine; // ステートマシンの参照
    private UIManager _uiManager; // UIManagerの参照
    private EventManager _eventManager; // EventManagerの参照

    // コンストラクタ
    public OpenTreasureState(Statemachine machine, UIManager uiManager, EventManager eventManager)
    {
        _machine = machine;
        _uiManager = uiManager;
        _eventManager = eventManager;
    }

    // 状態のプレイ処理
    public IEnumerator Play(Context context)
    {
        Debug.Log("宝箱を開いています...");
        yield return new WaitForSeconds(1); // 1秒待機

        // UIを更新
        _uiManager.UpdateTreasureUI("あなたが見つけた宝物: 古いコイン");

        // 宝箱を開け終わった後、フィールド状態に戻る
        _machine.ChangeState(new FieldState(_machine, _eventManager, _uiManager));
    }

    // 更新処理
    public IEnumerator Update(Context context)
    {
        yield return null; // 更新処理がない場合はnullを返す
    }

    // 状態終了処理
    public void Exit()
    {
        // クリーンアップ処理
    }
}
