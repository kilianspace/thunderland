using UnityEngine;
using UnityEngine.UI; // 必要な名前空間
using System.Collections.Generic;

// IUIManagerを継承したUIマネージャのラッパークラス
public class UIManagerDictionary
{
    private Dictionary<string, IUIManager> _uiManagers; // UIマネージャを格納する辞書

    public UIManagerDictionary()
    {
        _uiManagers = new Dictionary<string, IUIManager>();
    }

    // UIマネージャを追加するメソッド
    public void AddUIManager(string key, IUIManager uiManager)
    {
        if (!_uiManagers.ContainsKey(key))
        {
            _uiManagers.Add(key, uiManager);
        }
        else
        {
            Debug.LogWarning($"UIManager with key '{key}' already exists.");
        }
    }

    // UIマネージャを取得するメソッド
    public IUIManager GetUIManager(string key)
    {
        _uiManagers.TryGetValue(key, out IUIManager uiManager);
        return uiManager;
    }

    // UIマネージャを削除するメソッド
    public void RemoveUIManager(string key)
    {
        if (_uiManagers.ContainsKey(key))
        {
            _uiManagers.Remove(key);
        }
        else
        {
            Debug.LogWarning($"UIManager with key '{key}' does not exist.");
        }
    }
}
