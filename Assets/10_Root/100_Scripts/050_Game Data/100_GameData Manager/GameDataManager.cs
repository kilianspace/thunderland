using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// ユーザーインターフェースを管理するクラス
public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; } // シングルトンインスタンス

    private GameDataCollection _collection; // 実際のデータ管理用のフィールド
    public GameDataCollection Collection
    {
        get { return _collection; }
        set { _collection = value; }
    }

    void Awake()
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

        // GameDataCollectionのインスタンスを作成
        _collection = gameObject.AddComponent<GameDataCollection>();

        // CSVからモンスターのデータを読み込む
        string csvPath = FilePath.MONSTER_SEED_DATA;  // CSVファイルのパス
        MonsterLoader monsterLoader = new MonsterLoader(csvPath);
        Dictionary<string, Monster> monsterData = monsterLoader.LoadMonsterFromCSV();

        // データをGameDataCollectionに追加
        _collection.AddMonsterData(GameDataKeyConstants.MONSTER_DATA, monsterData);
    }

    public void Start()
    {
        // IGameData型のデータを取得
        IGameData gameData = _collection.GetGameData(GameDataKeyConstants.MONSTER_DATA, "Dragon");

        // 明示的にキャスト
        Monster monsterData = gameData as Monster;

        // キャストが成功したかどうかを確認
        if (monsterData != null)
        {
            Debug.Log($"Monster Name: {monsterData.Name}, Health: {monsterData.Health}");
        }
        else
        {
            Debug.LogWarning("The retrieved game data is not a Monster.");
        }
    }
}
