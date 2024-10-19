using System.Collections;
using UnityEngine;

/// <summary>
/// CoroutineHandlerはコルーチンの管理を簡略化するためのクラスです。
///
/// - シングルトンパターンを使用し、アプリケーション全体で一つのインスタンスを持つことを保証します。
/// - DontDestroyOnLoadを使い、シーン遷移時に破棄されず継続して使用可能です.
/// - 静的なStartNewCoroutineメソッドを通じて、他のクラスから簡単にコルーチンを開始できます.
///
/// これにより、コルーチンの管理が効率的になり、コードの可読性と保守性が向上します.
/// </summary>
public class CoroutineHandler : MonoBehaviour
{
    private static CoroutineHandler _instance;

    public static CoroutineHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("CoroutineHandler");
                _instance = obj.AddComponent<CoroutineHandler>();
                DontDestroyOnLoad(obj);
            }
            return _instance;
        }
    }

    public static void StartNewCoroutine(IEnumerator coroutine) // メソッド名を変更
    {
        Instance.StartCoroutine(coroutine); // インスタンスを通じてコルーチンを開始
    }
}
