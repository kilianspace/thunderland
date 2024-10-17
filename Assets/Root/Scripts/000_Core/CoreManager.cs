using UnityEngine;

public class CoreManager : MonoBehaviour
{
    // シングルトンインスタンス
    public static CoreManager Instance { get; private set; }

    private FlowManager _flowManager; // FlowManagerのインスタンスを保持する

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

    void Start()
    {
        // FlowManagerを生成
        _flowManager = gameObject.AddComponent<FlowManager>();
    }

    // 必要に応じてCoreManagerで提供するメソッドを追加
    public FlowManager GetFlowManager()
    {
        return _flowManager;
    }
}
