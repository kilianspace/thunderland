using System.Collections;
using UnityEngine;

// 状態遷移を管理するためのステートマシン
public class Statemachine : MonoBehaviour
{
    private IState _currentState; // 現在の状態を保持する変数
    private Coroutine _task; // 実行中のコルーチンを保持する変数
    private Context _context; // アルバムのコンテキストを保持する変数
    private UIManager _uiManager; // UIを管理するUIManagerの参照
    private EventManager _eventManager; // EventManagerの参照

    // CurrentStateプロパティを追加
    public IState CurrentState => _currentState; // 現在の状態を取得するプロパティ

    // ステートマシンの初期化処理
    void Start()
    {
        // DiscographyModelのインスタンスを作成
        DiscographyModel cd = new DiscographyModel();
        // AlbumContextを初期化
        _context = new Context(null, cd);
        // UIManagerとEventManagerをシーンから取得
        _uiManager = FindObjectOfType<UIManager>();
        _eventManager = FindObjectOfType<EventManager>(); // EventManagerも取得する

        // 初期状態として FieldState を設定
        ChangeState(new FieldState(this, _eventManager, _uiManager));
    }

    // 状態を変更するためのメソッド
    public void ChangeState(IState newState)
    {
        Debug.Log($"Changing state from {_currentState} to {newState}");

        // 新しい状態がnullの場合のエラーチェック
        if (newState == null)
        {
            Debug.LogError("新しい状態がnullです。");
            return;
        }

        // 現在実行中のコルーチンを停止
        if (_task != null)
        {
            StopCoroutine(_task); // 以前のコルーチンを停止
            _currentState?.Exit(); // 以前の状態のExitメソッドを呼び出す
        }

        // 新しい状態に変更
        _currentState = newState;
        // 新しい状態のコルーチンを開始
        _task = StartCoroutine(Run());
    }

    // 現在の状態の実行を管理するコルーチン
    private IEnumerator Run()
    {
        // 現在の状態がnullでない場合
        if (_currentState != null)
        {
            Log.ObjectInfo("Play", _currentState, 1);

            // 状態のPlayメソッドを呼び出し、完了するまで待機
            yield return _currentState.Play(_context);

            // 無限ループで状態のUpdateメソッドを実行
            while (true)
            {
                Log.ObjectInfo("Update", _currentState, 1);

                yield return _currentState.Update(_context); // 更新処理を実行
            }
        }
        else
        {
            Debug.LogError("現在の状態がnullです。");
        }
    }
}
