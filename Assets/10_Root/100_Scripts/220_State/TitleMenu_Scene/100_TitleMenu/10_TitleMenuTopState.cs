using System.Collections; // IEnumeratorのため
using UnityEngine; // MonoBehaviourのため

public class TitleMenuTopState : IState
{


    // Context
    /////////////////////////////////////////
    private StateContext _context;
    // インターフェースの必須メソッド
    //////
    public StateContext GetContext()
    {
        return _context;
    }
    //////
    public void SetContext(StateContext context)
    {
        _context = context;
    }
    /////////////////////////////////////////


    // UI Manager
    /////////////////////////////////////////
    private IUIManager TitleMenuTopUIManager;
    /////////////////////////////////////////




    public IEnumerator Run()
    {

        // UIManagerシングルトン内で取得済み
        /////////////////////////////////////////
        TitleMenuTopUIManager = _context.UIManager.Collection.GetUIManager(UIManagerNameKeyConstants.TITLEMENU_TOP);
        /////////////////////////////////////////

        yield return null; // フィールド状態が1フレーム実行されることを示す
    }

    public IEnumerator PerformFrame()
    {
        TitleMenuTopUIManager.HandleInput(); // ここでタイトルメニューの入力を処理


        yield return null; // 更新処理を1フレーム実行
    }

    public void WillExit()
    {
        Debug.Log("TitleMenuTopState から離れる...");
    }

    public bool ShouldTransition(out IState nextState)
    {
        nextState = null; // 初期値をnullに設定



        // 次の状態が設定されたかどうかを返す
        return nextState != null;
    }
}
