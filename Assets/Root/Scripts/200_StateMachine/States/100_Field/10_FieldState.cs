using System.Collections;
using UnityEngine;

// フィールドの状態を管理するクラス
public class FieldState : IState
{
    private Statemachine _machine; // ステートマシンの参照
    private EventManager _eventManager; // EventManagerの参照
    private UIManager _uiManager; // UIManagerの参照

    // コンストラクタ
    public FieldState(Statemachine machine, EventManager eventManager, UIManager uiManager)
    {
        _machine = machine; // ステートマシンのインスタンスを取得
        _eventManager = eventManager; // EventManagerのインスタンスを取得
        _uiManager = uiManager; // UIManagerのインスタンスを取得

        // 宝箱開けイベントを登録
        _eventManager.StartListening("OpenTreasureBox", OnOpenTreasureBox);
    }

    // 状態のプレイ処理
    public IEnumerator Play(Context context)
    {
        Debug.Log("フィールドの状態をプレイ中");

        while (true) // フィールド状態がアクティブな間
        {
            // 更新処理を呼び出す
            yield return Update(context);

            // Qキーが押されたらフィールド状態を抜ける
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("フィールド状態を終了します。");
                _machine.ChangeState(null); // 遷移先の状態を指定する場合はここに追加
                break; // whileループを抜けて状態を終了
            }
        }
    }

    // 更新処理
    public IEnumerator Update(Context context) // public に修正
    {
        // 入力処理
        HandleInput();

        // 状態がアクティブな間の追加処理があればここに書く
        yield return null; // フレームごとに待機
    }

    // 入力処理
    private void HandleInput()
    {
        // Enterキーが押された場合、宝箱を開ける処理を呼び出す
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enterキーが押されました。");
            OpenTreasureBox();
        }
    }

    // 宝箱を開けるイベントに対する処理
    private void OpenTreasureBox()
    {
        Debug.Log("宝箱を開けるイベントが発火しました。");
        _machine.ChangeState(new OpenTreasureState(_machine, _uiManager, _eventManager)); // 宝箱を開く状態に遷移
    }

    // 状態の終了処理
    public void Exit()
    {
        // 状態が終了する際の処理をここに書く
        Debug.Log("フィールドの状態が終了しました。");
        _eventManager.StopListening("OpenTreasureBox", OnOpenTreasureBox); // イベントリスナーを解除
    }

    // 宝箱を開けるイベントに対する処理
    private void OnOpenTreasureBox()
    {
        OpenTreasureBox(); // 宝箱を開ける処理を呼び出す
    }
}
