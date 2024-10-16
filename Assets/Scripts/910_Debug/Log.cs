using UnityEngine;

public class Log
{



    private static int _counter;

    public static void Object(object obj)
    {
        Debug.Log(obj);
    }
    public static void Info(string message, int count = 0)
    {

        if(count != 0){
          _counter += count;
        }

        Debug.Log("[ <color=yellow>"  + _counter + " </color>] "+  message);
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

}
