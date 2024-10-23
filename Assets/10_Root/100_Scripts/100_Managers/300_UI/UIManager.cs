using UnityEngine;
using UnityEngine.UI; // 必要な名前空間
using System.Collections.Generic;

// ユーザーインターフェースを管理するクラス
public class UIManager : MonoBehaviour, IUIManager
{
    public static UIManager Instance { get; private set; } // シングルトンインスタンス


    private UIManagerDictionary _uiManagerDictionary; // UIマネージャ辞書のインスタンス

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
        _uiManagerDictionary = new UIManagerDictionary(); // 辞書の初期化

    }

    public void UpdateUI()
    {

    }

    // UIマネージャを追加するメソッド
    public void AddUIManager(string key, IUIManager uiManager)
    {
        _uiManagerDictionary.AddUIManager(key, uiManager);
    }

    // UIマネージャを取得するメソッド
    public IUIManager GetUIManager(string key)
    {
        return _uiManagerDictionary.GetUIManager(key);
    }
}
