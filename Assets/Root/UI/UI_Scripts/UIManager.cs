using UnityEngine;
using UnityEngine.UI; // 必要な名前空間

// ユーザーインターフェースを管理するクラス
public class UIManager : MonoBehaviour, IUIManager
{
    public Text treasureText; // ヒエラルキーに設置したレガシーTextオブジェクトの参照

     private FlowManager _flowManager;

     private void Start()
     {
         if (treasureText == null)
         {
             Debug.LogError("treasureTextが設定されていません。");
         }


         treasureText.text = "なんだこれ";
     }

     public void UpdateUI(string info)
     {
         if (info != null)
         {
             treasureText.text = info;
         }
     }

}
