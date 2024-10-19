using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement; // シーン管理に必要


public class SceneExitState : IState
{
    private StateContext _context;



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
        SceneManager.LoadScene("CamelScene");
        yield break; // コルーチンを終了し、シーン遷移
    }

    public void WillExit()
    {
        Debug.Log("SceneSetupSstateを離脱します");
    }

    public bool ShouldTransition(out IState nextState)
    {
        nextState = this;
        return nextState != null;
    }

}
