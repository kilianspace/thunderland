using UnityEngine;

public class CoreManager : MonoBehaviour
{
    // シングルトンインスタンス
    public static CoreManager Instance { get; private set; }

    private FlowManager _flowManager; // FlowManagerのインスタンスを保持する

    // デバッグフラグ
    public static bool IsDebugMode { get; set; } = true; // デフォルトはtrue（開発中）

    void Awake()
    {
        // シングルトンのインスタンスを設定
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンが変更されても破棄されない
        }
        else
        {
            Destroy(gameObject); // 既存のインスタンスがあればこのオブジェクトを破棄
        }
    }

    public void Start() // アクセス修飾子をpublicに変更
    {
        // FlowManagerが存在しない場合に新しく生成
        InitializeFlowManager();
    }

    // FlowManagerを初期化するためのメソッド
    public void InitializeFlowManager()
    {
        if (_flowManager == null)
        {
            _flowManager = gameObject.AddComponent<FlowManager>();
            Debug.Log("FlowManagerが生成されました。");
        }
    }

    // FlowManagerを取得するためのメソッド
    public FlowManager GetFlowManager()
    {
        return _flowManager;
    }


    //この方法では、FlowManager の削除が完了したことを確認できるため、次の処理（新しいシーンの読み込み）を確実に行うことができます。待機時間を指定するのではなく、処理の完了を待つことで、意図した通りの動作が保証されるのです。
    public void RemoveFlowManager(System.Action callback)
    {
        if (_flowManager != null)
        {
            Destroy(_flowManager); // FlowManagerを破棄
            _flowManager = null; // 参照をクリア
            callback?.Invoke(); // コールバックを呼び出す
        }
    }
}
