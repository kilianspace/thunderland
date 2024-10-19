using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要
using System.Collections;
using System;
using TMPro; // TextMesh Pro 用の名前空間

[System.Serializable]
public class DebugCornerStatsUIManager : MonoBehaviour, IUIManager
{
    private static DebugCornerStatsUIManager _instance; // シングルトンインスタンス

    [SerializeField] private TextMeshProUGUI scneName; // ステートを表示するTextMeshProUGUIコンポーネント
    [SerializeField] private TextMeshProUGUI stateName; // ステートを表示するTextMeshProUGUIコンポーネント

    // プロパティを使用してインスタンスにアクセスするためのメソッド
    public static DebugCornerStatsUIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // シーン内のDebugCornerStatsUIManagerを検索
                _instance = FindObjectOfType<DebugCornerStatsUIManager>();
                if (_instance == null)
                {
                    Debug.LogError("DebugCornerStatsUIManagerがシーン内に存在しません。");
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // すでにインスタンスが存在する場合は、現在のオブジェクトを破棄
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // インスタンスを設定
        _instance = this;
        DontDestroyOnLoad(gameObject); // シーン間でオブジェクトを保持
    }

    // ステートを更新するメソッド
    public void UpdateUI(string test)
    {
        // 実装内容に応じて更新処理を追加
    }

    // シーン名を更新するメソッド
    public void WhichScene(string scene)
    {
        scneName.text = scene;
    }

    // ステートを更新するメソッド
    public void WhichState(string state)
    {
        stateName.text = state;
    }
}
