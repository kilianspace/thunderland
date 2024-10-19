using System.Collections;
using UnityEngine;

public class ShopState : IState
{
    private StateContext _context;

    public void SetContext(StateContext context)
    {
        _context = context;
    }

    public IEnumerator Run()
    {
        Debug.Log("ショップを開く...");
        yield return null; // ショップ状態が1フレーム実行されることを示す
    }

    public IEnumerator PerformFrame()
    {
        // ショップ状態の更新処理
        Debug.Log("ショップ状態の更新処理");
        yield return null; // 更新処理を1フレーム実行
    }

    public void WillExit()
    {
        Debug.Log("ショップ状態から離れる...");
    }
}
