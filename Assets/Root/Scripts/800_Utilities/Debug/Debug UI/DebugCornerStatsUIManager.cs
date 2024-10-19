
using UnityEngine;
using TMPro; // TextMesh Pro 用の名前空間

public class DebugCornerStatsUIManager : MonoBehaviour, IUIManager
{
    public TextMeshProUGUI scneName; // ステートを表示するTextMeshProUGUIコンポーネント
    public TextMeshProUGUI stateName; // ステートを表示するTextMeshProUGUIコンポーネント


    // ステートを更新するメソッド
    public void UpdateUI(string test)
    {
    }


    // シーン名を更新するメソッド
    public void WhichScene(string scene)
    {
        scneName.text = scene;

    }
    // ステートを更新するメソッド
    public void WhichState(string state)
    {
        stateName.text = state;

    }

}
