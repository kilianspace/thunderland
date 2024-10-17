using System;
using System.Collections.Generic;
using UnityEngine;

// イベントの管理を行うクラス
public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>(); // イベント名とそのリスナーを保持する辞書

    // イベントをリスンするためのメソッド
    public void StartListening(string eventName, Action listener)
    {
        if (!eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] = null; // イベント名が未登録の場合、初期化
        }
        eventDictionary[eventName] += listener; // リスナーを登録
    }

    // イベントを停止するためのメソッド
    public void StopListening(string eventName, Action listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] -= listener; // リスナーを解除
        }
    }

    // イベントをトリガーするためのメソッド
    public void TriggerEvent(string eventName)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName]?.Invoke(); // 登録されたリスナーを呼び出す
        }
    }

    // シングルトンのインスタンス
    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // シーン内でEventManagerが存在しない場合、GameObjectを作成
                GameObject obj = new GameObject("EventManager");
                _instance = obj.AddComponent<EventManager>();
                DontDestroyOnLoad(obj); // シーン遷移でも破棄しないようにする
            }
            return _instance;
        }
    }
}
