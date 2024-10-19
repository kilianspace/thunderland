using System.Collections.Generic;
using UnityEngine;



/// SignalBucketクラス（外部からはアクセス不可）
public class SignalBucket
{
    private Dictionary<string, System.Action> eventDictionary = new Dictionary<string, System.Action>(); // イベント名とリスナーの辞書

    // プライベートコンストラクタ
    internal SignalBucket() {} // アクセス修飾子をinternalにすることで、同一アセンブリ内からはアクセス可能にする

    // イベントをプールにドロップインする（リスナーの登録）
    public void DropIn(string eventName, System.Action listener)
    {
        if (!eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] = null; // 初期化
            Debug.Log("新しいイベントを登録しました: " + eventName);
        }
        eventDictionary[eventName] += listener;
    }

    // イベントをプールからドロップアウトする（リスナーの削除）
    public void DropOut(string eventName, System.Action listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] -= listener;
        }
    }

    // イベントをポップ（トリガーする）
    public void Pop(string eventName)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            Debug.Log("イベントをポップしています: " + eventName);
            eventDictionary[eventName]?.Invoke(); // リスナーを呼び出す
        }
        else
        {
            Debug.LogError("イベント名が見つかりません: " + eventName);
        }
    }
}
