using System.Collections;
public interface IState
{
    void SetContext(StateContext context);
    IEnumerator Run();
    IEnumerator PerformFrame();
    void WillExit();
}
