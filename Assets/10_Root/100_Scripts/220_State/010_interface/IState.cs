using System.Collections;
public interface IState
{
    void SetContext(StateContext context);
    StateContext GetContext(); // 追加
    IEnumerator Run();
    IEnumerator PerformFrame();
    void WillExit();


    bool ShouldTransition(out IState nextState);


}
