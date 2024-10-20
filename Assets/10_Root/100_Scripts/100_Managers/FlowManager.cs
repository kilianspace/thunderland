using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要
using System.Collections;
using System;


// ゲーム全体のフローを管理するクラス
[System.Serializable]
public class FlowManager : MonoBehaviour
{

    [SerializeField] private StateContext _context;
    private Statemachine _statemachine;
    private SignalPool _signalPool;


    // Debug UI
    ///////////////////////////////////////////////
    [SerializeField] private DebugCornerStatsUIManager _debugCornerStatsUIManager;
    ///////////////////////////////////////////////

    // 初期化処理
    // FlowManagerの初期化処理
    private void Start()
    {
        // InitializeFlowManagerコルーチンを開始
        StartCoroutine(InitializeFlowManager());
    }



    private IEnumerator InitializeFlowManager()
    {

        // Statemachine
        ///////////////////////////////////////////////
        _statemachine = GetComponent<Statemachine>();
         if (_statemachine == null)
         {
             // StateMachineが見つからなかった場合、新たに追加する
             _statemachine = gameObject.AddComponent<Statemachine>();
         }
        ///////////////////////////////////////////////

        // SignalPool
        ///////////////////////////////////////////////
         _signalPool = SignalPool.Instance; // シングルトンインスタンスを取得
        if (_signalPool == null)
        {
            Debug.LogError("SignalPoolが取得できませんでした。");
            yield break; // 終了
        }
        ///////////////////////////////////////////////


        // Debugging
        ///////////////////////////////////////////////
        // DebugCornerStatsUIManagerの生成を待つ
        yield return new WaitUntil(() => FindObjectOfType<DebugCornerStatsUIManager>() != null);
        _debugCornerStatsUIManager = FindObjectOfType<DebugCornerStatsUIManager>();
        if (_debugCornerStatsUIManager != null)
        {
            if (CoreManager.IsDebugMode)
            {
                _debugCornerStatsUIManager.WhichScene(SceneManager.GetActiveScene().name);
                // SignalBucketを登録
                _signalPool.RegisterSignalBucket("StateChanged");
                // StatemachineのSwitchState内でイベントを発行している
                _signalPool.GetSignalBucket("StateChanged")?.DropIn("StateChanged", UpdateStateText);
            }
        }
        else
        {
            Debug.LogError("DebugCornerStatsUIManagerが見つかりません。");
            yield break; // 終了
        }
        ///////////////////////////////////////////////





        // Optional UIManager
        ///////////////////////////////////////////////
        IUIManager _uiManager = FindObjectOfType<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("UIManagerが見つかりません。");
            yield break; // 終了
        }
        ///////////////////////////////////////////////


        // State Context
        ///////////////////////////////////////////////
        Debug.Log("_signalPool: " + _signalPool);
        Debug.Log("_uiManager: " + _uiManager);
        _context = StateContext.Create(_statemachine, _signalPool).WithOptionalUIManager(_uiManager);
        ///////////////////////////////////////////////


        // 初期状態を設定
        ///////////////////////////////////////////////
        ActivateInitialState(_context);  // context を引数として渡す
        ///////////////////////////////////////////////

    }



    // 初期状態を設定するメソッド
    private void ActivateInitialState(StateContext context)
    {
        var sceneSetupState = _statemachine.GetOrCreateState<SceneSetupSstate>(context);
        _statemachine.SwitchState(sceneSetupState);
    }




    // Debug Methods
    ///////////////////////////
    private void UpdateStateText()
    {
        // 現在のステート名を取得してテキストを更新する処理
        var currentStateName = _context.Statemachine.GetCurrentStateName(); // ステートマシンの現在のステート名を取得するメソッド
        _debugCornerStatsUIManager.WhichState(currentStateName);
    }
    private void OnDestroy()
    {
        // リスナーを削除してメモリリークを防ぐ
        _signalPool.GetSignalBucket("StateChanged")?.DropOut("StateChanged", UpdateStateText);
        Log.Info("FlowManager => OnDestroy()");
    }
    ///////////////////////////



}
