using System.Collections; // IEnumerator、Coroutineのため
using System.Collections.Generic; // Dictionaryのため
using UnityEngine; // MonoBehaviourのため

public class Statemachine : MonoBehaviour
{



    /////////////////////////////////////////
    private IState _currentState;
    public IState CurrentState => _currentState;
    /////////////////////////////////////////


    /////////////////////////////////////////
    private IState _nextState; // 修正：変数名を修正
    public IState NextState => _nextState; // デバッグ表示に使用
    /////////////////////////////////////////


    /////////////////////////////////////////
    private Coroutine _task; // 実行中のコルーチンを保持する変数
    /////////////////////////////////////////



    // 状態インスタンスを保持するための辞書
    /////////////////////////////////////////
    private Dictionary<System.Type, IState> _stateInstances = new Dictionary<System.Type, IState>();
    /////////////////////////////////////////



    // 新規作成もしくは状態を取得するメソッド
    /////////////////////////////////////////
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
    /////////////////////////////////////////



    // 状態を変更するためのメソッド
    /////////////////////////////////////////
    public void SwitchState(IState newState)
    {
        if (newState == null)
        {
            Debug.LogError("新しい状態がnullです。");
            return;
        }

        // Debug
        ///////////////////////////////////////////////////
        if(CoreManager.IsDebugMode)
        {
            Debug.Log($"Changing state from {_currentState} to {newState}");
            SignalPool.Instance.GetSignalBucket(EventContants.STATE_CHANGED)?.Pop(EventContants.STATE_CHANGED);
        }
        ////////////////////////////////////////////////////

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
    /////////////////////////////////////////



    // 現在の状態の実行を管理するコルーチン
    /////////////////////////////////////////
    private IEnumerator ExecuteCurrentState()
    {
        if (_currentState != null)
        {
            // 現在の状態のRunメソッドを実行し、その完了を待つ
            yield return _currentState.Run();

            // 状態遷移のチェック
            while (true)
            {
                yield return _currentState.PerformFrame(); // 現在の状態のPerformFrameメソッドを実行

                // 状態遷移のチェック
                if (_currentState.ShouldTransition(out IState nextState))
                {
                    _nextState = nextState; // 修正：変数名を修正


                    _nextState.SetContext(_currentState.GetContext()); // コンテキストを渡す



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
    /////////////////////////////////////////


    
    // Debug Methods
    ///////////////////////////
    public string GetCurrentStateName()
    {
        return _nextState?.GetType().Name ?? "None"; // 修正：変数名を修正
    }
    ///////////////////////////
}
