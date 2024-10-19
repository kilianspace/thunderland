using System.Collections.Generic;
using UnityEngine;


// SignalPoolクラス（外部からアクセス可能）
public class SignalPool : MonoBehaviour
{
    private static SignalPool _instance;

    private Dictionary<string, SignalBucket> signalBuckets = new Dictionary<string, SignalBucket>(); // SignalBucketの管理

    public static SignalPool Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("SignalPool");
                _instance = obj.AddComponent<SignalPool>();
                DontDestroyOnLoad(obj); // シーン遷移時も破棄されない
            }
            return _instance;
        }
    }

    // SignalBucketを取得
    public SignalBucket GetSignalBucket(string name)
    {
        if (signalBuckets.TryGetValue(name, out var bucket))
        {
            return bucket;
        }
        else
        {
            Debug.LogError("SignalBucketが見つかりません: " + name);
            return null;
        }
    }

    // SignalBucketを登録または作成
    public void RegisterSignalBucket(string name)
    {
        if (!signalBuckets.ContainsKey(name))
        {
            signalBuckets[name] = new SignalBucket(); // 新しいSignalBucketを作成
            Debug.Log("新しいSignalBucketを登録しました: " + name);
        }
    }
}
