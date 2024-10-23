using System.Collections.Generic;

// ベースクラス
// ンターフェースは[System.Serializable]がつかえない。したがってJSONUtilityが使えず。メンバー、キャラ共通のデータを一括で取り込むことができない。そのために共通クラスCharacterBaseを作ってこれを取り込むことにする
// CharacterBase class
[System.Serializable]
public class CharacterBase
{

    //CharacterBase クラスのプロパティに get と set を使用していると、Unity の JsonUtility はデフォルトのプロパティをシリアライズできません。JsonUtility はフィールドをシリアライズするため、プロパティをフィールドに変更することを検討してください。
    public int ID; // 直接フィールドを使用
    public string Name;
    public int HP;
    public int Attack;
    public int Defense;
    public List<string> SpecialSkills = new List<string>(); // Always initialized
}
