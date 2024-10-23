using UnityEngine;
using UnityEngine.UI; // 必要な名前空間
using System.Collections.Generic;

public class GameDataCollection
{
    private Dictionary<string, IGameData> _dictionary; // UIマネージャを格納する辞書
    public Dictionary<string, IGameData> Dictionary
    {
        get { return _dictionary; }
        set { _dictionary = value; }
    }

    public GameDataCollection()
    {
        _dictionary = new Dictionary<string, IGameData>();
    }

    // UIマネージャを追加するメソッド
    public void AddGameData(string key, IGameData gameData)
    {
        if (!_dictionary.ContainsKey(key))
        {
            _dictionary.Add(key, gameData);
        }
        else
        {
            Debug.LogWarning($"GameData with key '{key}' already exists.");
        }
    }

    // UIマネージャを取得するメソッド
    public IGameData GetGameData(string key)
    {
        _dictionary.TryGetValue(key, out IGameData gameData);
        return gameData;
    }

    // UIマネージャを削除するメソッド
    // public void RemoveGameData(string key)
    // {
    //     if (_dictionary.ContainsKey(key))
    //     {
    //         _dictionary.Remove(key);
    //     }
    //     else
    //     {
    //         Debug.LogWarning($"GameData with key '{key}' does not exist.");
    //     }
    // }
}
