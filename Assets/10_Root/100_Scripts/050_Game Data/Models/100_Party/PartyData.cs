using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// プレイヤーパーティーのデータを管理するクラス
[System.Serializable]
public class PartyData : MonoBehaviour, IGameData
{
    // 所持金
    public int Gold { get; set; }

    // パーティーメンバーのリスト
    public List<Member> Members { get; private set; }

    // 行動。戦闘パーティーの最大人数
    public int MAX_COMPANY_MEMBERS = 4;

    // コンストラクタ
    public PartyData()
    {
        Gold = 0; // 初期所持金は0
        Members = new List<Member>(); // メンバーリストの初期化
    }

    // メンバーを追加するメソッド
    public void AddMember(Member member)
    {
        if (Members.Count < MAX_COMPANY_MEMBERS)
        {
            Members.Add(member);
        }
        else
        {
            UnityEngine.Debug.LogWarning("パーティーの最大人数に達しました。");
        }
    }

    // メンバーを削除するメソッド
    public void RemoveMember(Member member)
    {
        if (Members.Contains(member))
        {
            Members.Remove(member);
        }
        else
        {
            UnityEngine.Debug.LogWarning("メンバーがパーティーに存在しません。");
        }
    }
}
