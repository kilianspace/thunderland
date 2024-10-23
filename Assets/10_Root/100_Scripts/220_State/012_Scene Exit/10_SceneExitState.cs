using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement; // シーン管理に必要


public class SceneExitState : IState
{
    private StateContext _context;

    public StateContext GetContext() // 実装
    {
        return _context;
    }

    public void SetContext(StateContext context)
    {
        _context = context;
    }

    public IEnumerator Run()
    {
        Debug.Log("新しいシーンを読み込み中。。。。");
        yield return new WaitForSeconds(2); // 3秒待機
    }

    public IEnumerator PerformFrame()
    {

        yield break; // コルーチンを終了し、シーン遷移
    }

    public void WillExit()
    {
        // FlowManagerを削除し、削除処理が完了したらOnFlowManagerRemovedメソッドを呼び出す
        // これにより、FlowManagerが持つリソースやイベントが正しく解放されることを保証する。
        CoreManager.Instance.RemoveFlowManager(OnFlowManagerRemoved);
    }

    // SceneExitState内のOnFlowManagerRemovedメソッド
    private void OnFlowManagerRemoved()
    {
        // FlowManagerの削除が完了した後に新しいシーンの読み込みを開始するコルーチンを起動する。
        // このタイミングで呼び出されることで、FlowManagerに関連する処理が全て終了したことが確約される。
        CoroutineHandler.StartNewCoroutine(LoadNewScene("CamelScene"));
    }

    private IEnumerator LoadNewScene(string sceneName)
    {
        // 必要なら少し待機（1秒待つ）
        yield return new WaitForSeconds(1);

        // 指定されたシーンを読み込む
        SceneManager.LoadScene(sceneName);

        // シーンを離脱する際のデバッグメッセージを表示
        Debug.Log("SceneSetupStateを離脱します");

        // FlowManagerを初期化するための処理を追加
        CoreManager.Instance.InitializeFlowManager();
    }


    public bool ShouldTransition(out IState nextState)
    {
        nextState = this;
        return nextState != null;
    }

}
