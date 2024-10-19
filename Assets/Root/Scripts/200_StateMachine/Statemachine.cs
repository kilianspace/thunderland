using System.Collections.Generic;
using System.Collections;
using UnityEngine;

// 状態遷移を管理するためのステートマシン
public class Statemachine : MonoBehaviour
{
    private IState _currentState; // 現在の状態を保持する変数
    public IState CurrentState => _currentState; // 現在の状態を取得するプロパティ

    private Coroutine _task; // 実行中のコルーチンを保持する変数

    // 状態インスタンスを保持するための辞書
    private Dictionary<System.Type, IState> _stateInstances = new Dictionary<System.Type, IState>();

    // 状態を取得するメソッド
    public T GetOrCreateState<T>(StateContext context) where T : IState, new()
    {
        System.Type type = typeof(T);
        if (!_stateInstances.TryGetValue(type, out IState state))
        {
            state = new T();
            _stateInstances[type] = state;
        }

        // 状態のコンテキストを設定
        state.SetContext(context); // ここで状態のコンテキストを設定します

        return (T)state;
    }

    // 状態を変更するためのメソッド
    public void SwitchState(IState newState)
    {
        if (newState == null)
        {
            Debug.LogError("新しい状態がnullです。");
            return;
        }

        Debug.Log($"Changing state from {_currentState} to {newState}");

        // 現在実行中のコルーチンを停止
        if (_task != null)
        {
            StopCoroutine(_task); // 以前のコルーチンを停止
            _currentState?.WillExit(); // 以前の状態のWillExitメソッドを呼び出す
        }

        // 新しい状態に変更
        _currentState = newState;
        // 新しい状態のコルーチンを開始
        _task = StartCoroutine(ExecuteCurrentState());
    }

    // 現在の状態の実行を管理するコルーチン
    private IEnumerator ExecuteCurrentState()
    {
        if (_currentState != null)
        {
            yield return _currentState.Run(); // 現在の状態のRunメソッドを実行

            while (true)
            {
                // 現在の状態のPerformFrameメソッドを実行
                yield return _currentState.PerformFrame();

                // 状態遷移のチェック
                if (_currentState.ShouldTransition(out IState nextState))
                {
                    SwitchState(nextState); // 次の状態に遷移
                    yield break; // コルーチンを終了
                }
            }
        }
        else
        {
            Debug.LogError("現在の状態がnullです。");
        }
    }
}
