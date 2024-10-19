using UnityEngine;

// ゲーム全体のフローを管理するクラス
public class FlowManager : MonoBehaviour
{

    private StateContext _context;
    private Statemachine _statemachine;
    private SignalPool _signalPool;

    // 初期化処理
    // FlowManagerの初期化処理
    void Start()
    {

        // Statemachine
        ///////////////////////////////////////////////
        _statemachine = gameObject.AddComponent<Statemachine>();
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
        var fieldState = _statemachine.GetOrCreateState<FieldState>(context);
        _statemachine.SwitchState(fieldState);
    }

    // バトル状態に切り替えるメソッド
    public void SwitchToBattleState()
    {
        var battleState = _statemachine.GetOrCreateState<BattleState>(_context);
        _statemachine.SwitchState(battleState);
    }

    // ショップ状態に切り替えるメソッド
    public void SwitchToShopState()
    {
        var shopState = _statemachine.GetOrCreateState<ShopState>(_context);
        _statemachine.SwitchState(shopState);
    }
}
