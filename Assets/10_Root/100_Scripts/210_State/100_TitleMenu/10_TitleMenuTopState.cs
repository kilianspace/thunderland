using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleMenuTopState : IState
{
    private StateContext _context;

    public void SetContext(StateContext context)
    {
        _context = context;
    }

    public IEnumerator Run()
    {
        Debug.Log("タイトルメニューのトップにいる...");


        // コールバックを登録
        RegisterCallbacks();



        yield return null; // フィールド状態が1フレーム実行されることを示す
    }

    public IEnumerator PerformFrame()
    {
        // フィールド状態の更新処理
        Log.LogState(this.GetType());
        yield return null; // 更新処理を1フレーム実行
    }

    public void WillExit()
    {
        Debug.Log("TitleMenuTopState から離れる...");
    }

    public bool ShouldTransition(out IState nextState)
    {
        nextState = null; // 初期値をnullに設定

        // シーン遷移の条件をここに記述
        // 丸ボタンが押されたあとで、セレクトメニューの入った配列で「ゲーム開始」を格納している箱が選択されている場合

        // 次の状態が設定されたかどうかを返す
        return nextState != null;
    }



    // ゲームの状態を更新するメソッド
public void UpdateGameState(GameState newState)
{
    // 現在の状態に応じた入力のコールバックを解除
    UnregisterCallbacks();

    // 新しいゲーム状態を設定
    _currentGameState = newState;

    // 新しい状態に応じたコールバックを登録
    RegisterCallbacks();
}



// コールバックを登録するメソッド
private void RegisterCallbacks()
{
    if (_context.InputJunction != null)
    {
        _context.InputJunction.RegisterCallbacksForGameState(OnCircleCallback, OnUpCallback, OnDownCallback);
    }
}

// コールバックを解除するメソッド
private void UnregisterCallbacks()
{
    if (_context.InputJunction != null)
    {
        _context.InputJunction.UnregisterCallbacksForGameState(OnCircleCallback, OnUpCallback, OnDownCallback);
    }
}


    // Callback
    ////////////////////////////////////////
    // サークルボタン（"O"）が押された時のコールバック
    public void OnCircleCallback(InputAction.CallbackContext context)
    {
        Debug.Log("Menu item selected.");
        // メニューの決定処理をここに記述
    }

    // 上方向ボタンが押された時のコールバック
    public void OnUpCallback(InputAction.CallbackContext context)
    {
        Debug.Log("Move to previous menu item.");
        // リスト内で一つ上のアイテムに移動する処理
    }

    // 下方向ボタンが押された時のコールバック
    public void OnDownCallback(InputAction.CallbackContext context)
    {
        Debug.Log("Move to next menu item.");
        // リスト内で一つ下のアイテムに移動する処理
    }
    ////////////////////////////////////////
}
