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
    private DebugCornerStatsUIManager _debugCornerStatsUIManager;
    ///////////////////////////////////////////////


    // 初期化処理
    // FlowManagerの初期化処理
    void Start()
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
            return;
        }
        ///////////////////////////////////////////////


        // Debugging
        ///////////////////////////////////////////////
        if(CoreManager.IsDebugMode)
        {
            _debugCornerStatsUIManager = FindObjectOfType<DebugCornerStatsUIManager>();
            // デバッグモードが有効なときのみ表示を更新
            _debugCornerStatsUIManager.WhichScene(SceneManager.GetActiveScene().name);

            if (_debugCornerStatsUIManager == null)
            {
                Debug.LogError("DebugCornerStatsUIManagerが見つかりません。");
                return;
            }

        // SignalBucketを登録
        _signalPool.RegisterSignalBucket("StateChanged"); // ここでSignalBucketを登録
        // StatemachineのSwitchState内でイベントを発行している
        _signalPool.GetSignalBucket("StateChanged")?.DropIn("StateChanged", UpdateStateText);
        }
        ///////////////////////////////////////////////





        // Optional UIManager
        ///////////////////////////////////////////////
        IUIManager _uiManager = FindObjectOfType<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("UIManagerが見つかりません。");
            return;
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
