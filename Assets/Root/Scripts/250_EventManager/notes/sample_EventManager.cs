using System;
using System.Collections.Generic;

public class Sample_EventManager
{
    private Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    public void StartListening(string eventName, Action listener)
    {
        if (!eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] = null;
        }
        eventDictionary[eventName] += listener; // リスナーを登録
    }

    public void StopListening(string eventName, Action listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] -= listener; // リスナーを解除
        }
    }

    public void TriggerEvent(string eventName)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName]?.Invoke(); // イベントを発火
        }
    }
}
