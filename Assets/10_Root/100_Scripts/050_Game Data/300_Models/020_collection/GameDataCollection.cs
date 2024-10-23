using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameDataCollection : MonoBehaviour
{
    // IGameDataをキーとして持つDictionaryの辞書
    [SerializeField] private Dictionary<string, Dictionary<string, IGameData>> gameDataDictionary = new Dictionary<string, Dictionary<string, IGameData>>();

    // モンスターの辞書を追加するメソッド
    public void AddMonsterData(string key, Dictionary<string, Monster> monsterData)
    {
        // Monster の辞書を IGameData の辞書に変換
        Dictionary<string, IGameData> data = new Dictionary<string, IGameData>();

        foreach (var pair in monsterData)
        {
            data[pair.Key] = pair.Value; // MonsterをIGameDataとして格納
        }

        gameDataDictionary[key] = data;
    }

    // UIManagerの辞書を追加するメソッド
    public void AddUIManagerData(string key, Dictionary<string, IGameData> uiManagerData)
    {
        gameDataDictionary[key] = uiManagerData;
    }

    // 辞書からデータを取得するメソッド
    public IGameData GetGameData(string category, string name)
    {
        if (gameDataDictionary.TryGetValue(category, out var dataDictionary))
        {
            if (dataDictionary.TryGetValue(name, out var gameData))
            {
                return gameData;
            }
        }

        Debug.LogWarning($"Game data not found for category: {category}, name: {name}");
        return null;
    }
}
