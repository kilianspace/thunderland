using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// ユーザーインターフェースを管理するクラス
public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; } // シングルトンインスタンス

    private GameDataCollection _collection; // UIマネージャ辞書のインスタンス
    public GameDataCollection Collection
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
        _collection = new GameDataCollection(); // 辞書の初期化

        // PartyData
        Register<PartyData>(GameDataKeyConstants.PARTY_DATA);

    }


    // 任意のIUIManagerを継承したクラスを辞書に登録する汎用メソッド
    private void Register<T>(string key) where T : MonoBehaviour, IGameData
    {
        T gameData = FindObjectOfType<T>();
        if (gameData != null && !_collection.Dictionary.ContainsKey(key))
        {
            _collection.AddGameData(key, gameData);
        }
    }




}
