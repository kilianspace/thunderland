using System; // 基本的なシステムクラスを使用するための名前空間
using System.IO; // 入出力ストリーム操作のための名前空間
using System.Collections.Generic; // ジェネリックコレクション（リストや辞書など）のための名前空間
using UnityEngine; // Unityエンジンの機能を使用するための名前空間

// CharacterLoaderクラスはMonoBehaviourを継承しており、Unityのコンポーネントとして機能する
public class CharacterLoader : MonoBehaviour
{
    // CharacterをIDで管理するための辞書を宣言
    public Dictionary<int, CharacterBase> Characters = new Dictionary<int, CharacterBase>();

    // キャラクターをロードするためのメソッド
    public void LoadCharacters()
    {
        // CSVファイルからキャラクターをロードし、JSON形式に変換する
        string json = ConvertCSVToJson("100_SeedData/CSV/300_characters.csv");
        Debug.Log("Generated JSON: " + json); // 生成したJSONをデバッグログに表示
        LoadCharactersFromJson(json); // JSONからキャラクターをロード
    }

    // CSVファイルをJSON形式に変換するメソッド
    string ConvertCSVToJson(string filePath)
    {
        // CSVファイルのフルパスを生成
        string csvFilePath = Path.Combine(Application.streamingAssetsPath, filePath);
        // 指定したパスにファイルが存在するか確認
        if (!File.Exists(csvFilePath))
        {
            Debug.LogError($"File not found at {csvFilePath}"); // ファイルが見つからない場合、エラーメッセージを表示
            return string.Empty; // 空の文字列を返す
        }

        // CSVファイルを読み込むためのStreamReaderを使用
        using (StreamReader reader = new StreamReader(csvFilePath))
        {
            // キャラクターを格納するリストを宣言
            List<CharacterBase> characterList = new List<CharacterBase>();
            bool isHeader = true; // ヘッダー行をスキップするフラグ
            while (!reader.EndOfStream) // ファイルの終わりまでループ
            {
                // 1行ずつ読み込む
                string line = reader.ReadLine();
                if (isHeader)
                {
                    isHeader = false; // ヘッダー行を読み飛ばす
                    continue; // 次のループへ
                }

                // 読み込んだ行をカンマで分割し、配列に格納
                string[] values = line.Split(',');
                Debug.Log($"values.Length: {values.Length}"); // パースした値をログに表示
                // 読み取った値を確認するためにデバッグログに表示
                Debug.Log($"Parsed values: {string.Join(", ", values)}"); // パースした値をログに表示

                // 必要なカラム数（少なくとも9カラム）が存在するか確認
                if (values.Length >= 10) // 10列目をチェック
                {
                    if (values[2].Equals("Monster", StringComparison.OrdinalIgnoreCase))
                    {
                        Monster monster = new Monster
                        {
                            ID = int.TryParse(values[0], out int id) ? id : 0 ,// ここでは例外処理を入れると良い
                            Name = values[1],
                            HP = int.TryParse(values[3], out int hp) ? hp : 0, // デフォルト値を0にする
                            Attack = int.TryParse(values[4], out int attack) ? attack : 0, // デフォルト値を0にする
                            Defense = int.TryParse(values[5], out int defense) ? defense : 0, // デフォルト値を0にする
                            SpecialSkills = new List<string>(values[6].Split('|')),
                            DropItems = new List<string>(values[7].Split('|')),
                            DropRate = float.TryParse(values[8], out float dropRate) ? dropRate : 0f, // 0f をデフォルト値とする
                            Attribute = values[9] // 属性を設定
                        };

                        characterList.Add(monster);
                        Debug.Log($"Added monster: {monster.Name} (ID: {monster.ID}) with Attribute: {monster.Attribute}");
                    }
                    else if (values[2].Equals("Member", StringComparison.OrdinalIgnoreCase))
                    {
                        Member member = new Member
                        {
                            ID = int.TryParse(values[0], out int id) ? id : 0, // デフォルト値を設定
                            Name = values[1],
                            HP = int.TryParse(values[3], out int hp) ? hp : 0, // デフォルト値を設定
                            Attack = int.TryParse(values[4], out int attack) ? attack : 0, // デフォルト値を設定
                            Defense = int.TryParse(values[5], out int defense) ? defense : 0, // デフォルト値を設定
                            SpecialSkills = new List<string>(values[6].Split('|')) // SpecialSkillsの設定
                        };

                        characterList.Add(member);
                        Debug.Log($"Added member: {member.Name} (ID: {member.ID})");
                    }
                }
            }

            // 読み込んだキャラクターの総数をログに表示
            Debug.Log($"Total characters loaded: {characterList.Count}");

            // キャラクターリストをJSON形式に変換
            var wrapper = new CharacterListWrapper { Characters = characterList };
            string json = JsonUtility.ToJson(wrapper, true); // JSONに変換
            Debug.Log($"Generated JSON: {json}"); // 生成したJSONをログに表示
            return json; // 生成したJSONを返す
        }
    }

    // JSONからキャラクターをロードするメソッド
    void LoadCharactersFromJson(string json)
    {
        // JSONが空または無効な場合のエラーチェック
        if (string.IsNullOrEmpty(json))
        {
            Debug.LogError("JSON is empty or invalid"); // エラーメッセージを表示
            return; // 処理を終了
        }

        // JSONをCharacterListWrapperオブジェクトに変換
        CharacterListWrapper characterListWrapper = JsonUtility.FromJson<CharacterListWrapper>(json);

        // CharacterListWrapperがnullの場合のエラーチェック
        if (characterListWrapper == null)
        {
            Debug.LogError("CharacterListWrapper is null."); // エラーメッセージを表示
            return; // 処理を終了
        }
        // Characters配列がnullの場合のエラーチェック
        if (characterListWrapper.Characters == null)
        {
            Debug.LogError("CharacterListWrapper's Characters array is null."); // エラーメッセージを表示
            return; // 処理を終了
        }

        // キャラクターリストを辞書に追加
        foreach (var characterData in characterListWrapper.Characters)
        {
            // キャラクターの種類をチェックして辞書に追加
            if (characterData is Monster)
            {
                Characters[characterData.ID] = characterData; // モンスターを追加
            }
            else if (characterData is Member)
            {
                Characters[characterData.ID] = characterData; // メンバーを追加
            }
        }

        LogCharacterData(); // キャラクターデータをログに出力
    }

    // キャラクターデータをログに出力するメソッド
    void LogCharacterData()
    {
        foreach (var character in Characters.Values) // 辞書に保存されたキャラクターをループ
        {
            // キャラクターがモンスターの場合
            if (character is Monster monster)
            {
                Debug.Log($"Monster ID: {monster.ID}, Name: {monster.Name}, Type: {monster.Type}, " +
                          $"HP: {monster.HP}, Attack: {monster.Attack}, Defense: {monster.Defense}, " +
                          $"Special Skills: {string.Join(", ", monster.SpecialSkills)}, " +
                          $"Drop Items: {string.Join(", ", monster.DropItems)}, Drop Rate: {monster.DropRate}");
            }
            // キャラクターがメンバーの場合
            else if (character is Member member)
            {
                Debug.Log($"Member ID: {member.ID}, Name: {member.Name}, HP: {member.HP}, " +
                          $"Attack: {member.Attack}, Defense: {member.Defense}, " +
                          $"Special Skills: {string.Join(", ", member.SpecialSkills)}");
            }
        }
    }
}
