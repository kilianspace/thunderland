using UnityEngine;

public class Log
{


    public static void Object(object obj)
    {
        Debug.Log(obj);
    }
    public static void Info(string message)
    {
        Debug.Log(message);
    }

    public static void Warning(string message)
    {
        Debug.LogWarning(message);
    }

    public static void Error(string message)
    {
        Debug.LogError(message);
    }
    
}
