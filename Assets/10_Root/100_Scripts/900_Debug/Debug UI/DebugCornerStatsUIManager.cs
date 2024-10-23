using UnityEngine;

using UnityEngine.SceneManagement; // シーン管理のために必要
using System.Collections;
using System;

using TMPro; // TextMesh Pro 用の名前空間

[System.Serializable]
public class DebugCornerStatsUIManager : MonoBehaviour, IUIManager
{
    [SerializeField] private TextMeshProUGUI scneName; // ステートを表示するTextMeshProUGUIコンポーネント
    [SerializeField] private TextMeshProUGUI stateName; // ステートを表示するTextMeshProUGUIコンポーネント


    // ステートを更新するメソッド
    public void UpdateUI()
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


    public void HandleInput()
    {

    }

}
