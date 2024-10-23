using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// ユーザーインターフェースを管理するクラス
public class UIManager : MonoBehaviour, IUIManager
{
    public static UIManager Instance { get; private set; } // シングルトンインスタンス

    private UIManagerCollection _collection; // UIマネージャ辞書のインスタンス
    public UIManagerCollection Collection
    {
        get { return _collection; }
        set { _collection = value; }
    }

    private void Awake()
    {
        // シングルトンの設定
        if (Instance == null)
        {
            Instance = this; // インスタンスを設定
            DontDestroyOnLoad(gameObject); // シーン間でオブジェクトを保持
        }
        else
        {
            Destroy(gameObject); // 既に存在する場合は破棄
        }
    }

    private void Start()
    {
        _collection = new UIManagerCollection(); // 辞書の初期化

        // Title Top Menu Manager
        RegisterUIManager<TitleMenuUIManager>(UIManagerNameKeyConstants.TITLEMENU_TOP);

    }


    // 任意のIUIManagerを継承したクラスを辞書に登録する汎用メソッド
    private void RegisterUIManager<T>(string key) where T : MonoBehaviour, IUIManager
    {
        T uiManager = FindObjectOfType<T>();
        if (uiManager != null && !_collection.UIManagers.ContainsKey(key))
        {
            _collection.AddUIManager(key, uiManager);
        }
    }



    public void UpdateUI()
    {

    }


}
