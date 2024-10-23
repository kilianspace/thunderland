#if UNITY_EDITOR
using UnityEditor; // AssetDatabaseを使用するために必要
#endif
using System.IO;
using UnityEngine;

public class CSVToScriptableObject : MonoBehaviour
{
    public string csvFilePath = "Assets/StreamingAssets/100_SeedData/CSV/monster_100.csv"; // CSVファイルのパス
    public string outputPath = "Assets/ScriptableObject/Monsters/"; // スクリプタブルオブジェクトの出力先

    // CSVファイルを読み込み、スクリプタブルオブジェクトを生成する
    public void GenerateScriptableObjects()
    {
        // CSVファイルを読み込む
        string[] csvLines = File.ReadAllLines(csvFilePath);

        // 1行目はヘッダーなのでスキップ
        for (int i = 1; i < csvLines.Length; i++)
        {
            string[] rowData = csvLines[i].Split(',');

            // CSVのデータを基にモンスターを生成
            CreateMonsterData(rowData[0], int.Parse(rowData[1]), int.Parse(rowData[2]));
        }
    }

    // モンスターのスクリプタブルオブジェクトを生成する
    private void CreateMonsterData(string monsterName, int health, int attackPower)
    {
        MonsterData monsterData = ScriptableObject.CreateInstance<MonsterData>();

        // モンスターのデータを設定
        monsterData.monsterName = monsterName;
        monsterData.health = health;
        monsterData.attackPower = attackPower;

#if UNITY_EDITOR
        // スクリプタブルオブジェクトをアセットとして保存
        string assetPath = outputPath + monsterName + ".asset";
        AssetDatabase.CreateAsset(monsterData, assetPath);
        AssetDatabase.SaveAssets();
#endif
    }
}
