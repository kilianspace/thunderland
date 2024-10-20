using System.Collections;
using UnityEngine;

public class TitleMenuTopState : IState
{
    private StateContext _context;

    public void SetContext(StateContext context)
    {
        _context = context;
    }

    public IEnumerator Run()
    {
        Debug.Log("タイトルメニューのトップにいる...");
        yield return null; // フィールド状態が1フレーム実行されることを示す
    }

    public IEnumerator PerformFrame()
    {
        // フィールド状態の更新処理
        Log.LogState(this.GetType());
        yield return null; // 更新処理を1フレーム実行
    }

    public void WillExit()
    {
        Debug.Log("TitleMenuTopState から離れる...");
    }

    public bool ShouldTransition(out IState nextState)
    {
        nextState = null; // 初期値をnullに設定

        // シーン遷移の条件をここに記述
        // 丸ボタンが押されたあとで、セレクトメニューの入った配列で「ゲーム開始」を格納している箱が選択されている場合

        // 次の状態が設定されたかどうかを返す
        return nextState != null;
    }

}
