using System.Collections;
using UnityEngine;

public class FieldState : IState
{
    private StateContext _context;

    public void SetContext(StateContext context)
    {
        _context = context;
    }

    public IEnumerator Run()
    {
        Debug.Log("フィールドにいる...");
        yield return null; // フィールド状態が1フレーム実行されることを示す
    }

    public IEnumerator PerformFrame()
    {
        // フィールド状態の更新処理
        Debug.Log("フィールド状態の更新処理");
        yield return null; // 更新処理を1フレーム実行
    }

    public void WillExit()
    {
        Debug.Log("フィールド状態から離れる...");
    }
}
