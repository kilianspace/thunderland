using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor; // エディタスクリプトを使用するために必要

// モンスターをCSVから読み込むクラス
public class MonsterLoader
{
    private string _csvPath;

    public MonsterLoader(string csvPath)
    {
        _csvPath = csvPath;
    }

    public Dictionary<string, Monster> LoadMonsterFromCSV()
    {
        Dictionary<string, Monster> monsters = new Dictionary<string, Monster>();

        // CSVファイルを読み込む
        string[] csvLines = File.ReadAllLines(_csvPath);

        // 保存先フォルダが存在しない場合は作成
        string directoryPath = FilePath.MONSTER_SCRIPTABLE_OBJECTS;
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        for (int i = 1; i < csvLines.Length; i++)
        {
            string line = csvLines[i];
            string[] values = line.Split(',');

            if (values.Length < 5) continue; // 必要なプロパティが不足している場合はスキップ

            Monster monster = ScriptableObject.CreateInstance<Monster>();

            // 名前を設定
            string monsterName = values[0].Trim();
            monster.Name = monsterName; // プロパティを使用して名前を設定
            Log.Info(monsterName); // ログに名前を出力

            // ヘルスをパース
            if (!int.TryParse(values[1].Trim(), out int health))
            {
                Debug.LogError($"Failed to parse health for monster {monsterName}: {values[1]}");
                continue; // パース失敗で次の行へ
            }
            monster.Health = health; // ヘルス設定

            // 攻撃力をパース
            if (!int.TryParse(values[2].Trim(), out int attack))
            {
                Debug.LogError($"Failed to parse attack for monster {monsterName}: {values[2]}");
                continue; // パース失敗で次の行へ
            }
            monster.Attack = attack; // 攻撃力設定

            // 防御力をパース
            if (!int.TryParse(values[3].Trim(), out int defense))
            {
                Debug.LogError($"Failed to parse defense for monster {monsterName}: {values[3]}");
                continue; // パース失敗で次の行へ
            }
            monster.Defense = defense; // 防御力設定

            // 説明文を設定
            monster.Description = values[4].Trim(); // 説明

            // アセットとして保存するパスを指定
            string path = Path.Combine(directoryPath, $"{monsterName}.asset"); // 保存先パス
            AssetDatabase.CreateAsset(monster, path);
            AssetDatabase.SaveAssets();

            // 辞書に追加
            monsters[monsterName] = monster;
        }

        return monsters;
    }
}
