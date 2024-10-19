using System.Collections;
using UnityEngine;

public class BattleState : IState
{
    private StateContext _context;

    public void SetContext(StateContext context)
    {
        _context = context;
    }

    public IEnumerator Run()
    {
        Debug.Log("バトル開始...");
        yield return null; // バトル状態が1フレーム実行されることを示す
    }

    public IEnumerator PerformFrame()
    {
        // バトル状態の更新処理
        Debug.Log("バトル状態の更新処理");
        yield return null; // 更新処理を1フレーム実行
    }

    public void WillExit()
    {
        Debug.Log("バトル状態から離れる...");
    }
}
