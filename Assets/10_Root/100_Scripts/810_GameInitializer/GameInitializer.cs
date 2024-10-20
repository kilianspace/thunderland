using System.Collections; 
using UnityEngine;



// ゲーム開始時のシーンにオブジェクトとして設置すべし

public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
        // CoroutineHandlerを初期化するためにインスタンスを取得
        CoroutineHandler.Instance.StartCoroutine(InitializeGame());
    }

    private IEnumerator InitializeGame()
    {
        // ここでゲームの初期化処理を行う
        yield return null; // 一時的な待機（必要に応じて）

        // CoreManagerのインスタンスを確認し、必要に応じて生成する
        if (CoreManager.Instance == null)
        {
            GameObject coreManagerObject = new GameObject("CoreManager");
            coreManagerObject.AddComponent<CoreManager>();
            Debug.Log("CoreManagerを新しく生成しました。");
        }
        else
        {
            Debug.Log("既存のCoreManagerが見つかりました。");
        }

        // FlowManagerの生成も行う
        if (CoreManager.Instance.GetFlowManager() == null)
        {
            CoreManager.Instance.Start(); // FlowManagerの生成
        }

        // 他の初期化処理をここに追加
        Debug.Log("ゲームの初期化が完了しました。");
    }
}
