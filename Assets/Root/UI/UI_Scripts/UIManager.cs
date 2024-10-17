using UnityEngine;
using UnityEngine.UI; // 必要な名前空間

// ユーザーインターフェースを管理するクラス
public class UIManager : MonoBehaviour
{
    public Text treasureText; // ヒエラルキーに設置したレガシーTextオブジェクトの参照

    // スタートメソッド - ゲーム開始時に呼び出される
    private void Start()
    {
        // treasureTextが設定されているか確認
        if (treasureText == null)
        {
            Debug.LogError("treasureTextが設定されていません。"); // 設定されていない場合はエラーメッセージを表示
        }

        // 初期のテキストを設定
        treasureText.text = "なんだこれ";
    }

    // テキストを更新するメソッド
    public void UpdateTreasureUI(string treasureContent)
    {
        // treasureTextがnullでないか確認
        if (treasureText != null)
        {
            // テキストを更新
            treasureText.text = treasureContent;
            Debug.Log("宝箱の内容をUIに表示します: " + treasureContent); // デバッグ用メッセージを表示
        }
        else
        {
            Debug.LogError("treasureTextがnullです。"); // treasureTextがnullの場合はエラーメッセージを表示
        }
    }
}
