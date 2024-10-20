using UnityEngine;

public class Log
{
    private static int _counter;

    public static void Object(object obj, int count = 0)
    {
        if (count != 0)
        {
            _counter += count;
        }

        Debug.Log("[ <color=green>" + _counter + " </color>] " + obj);
    }

    public static void Info(string message, int count = 0)
    {
        if (count != 0)
        {
            _counter += count;
        }

        Debug.Log("[ <color=yellow>" + _counter + " </color>] " + message);
    }

    public static void ObjectInfo(string message, object obj, int count = 0)
    {
        if (count != 0)
        {
            _counter += count;
        }

        Debug.Log("[ <color=green>" + _counter + " </color>] " + " | " + message + " | Object => " + obj);
    }

    public static void Class(object obj)
    {
        Debug.Log("Class from => " + obj);
    }

    public static void Warning(string message)
    {
        Debug.LogWarning(message);
    }

    public static void Error(string message)
    {
        Debug.LogError(message);
    }

    // 現在の状態をログに表示するメソッドを追加（色を黄色に変更）
    public static void LogState(System.Type stateType)
    {
        Debug.Log("<color=yellow>Current State: " + stateType.Name + "</color>");
    }

    private static float _stateLogTimer = 0f;

    // 指定されたインターバルでオブジェクトの状態をログに表示するメソッド
    public static void LogObjectWithInterval(object obj, float interval)
    {
        _stateLogTimer += Time.deltaTime; // タイマーを更新
        if (_stateLogTimer >= interval)
        {
            Debug.Log("<color=yellow>Current Object: " + obj.GetType().Name + "</color>");
            _stateLogTimer = 0f; // タイマーをリセット
        }
    }
}
