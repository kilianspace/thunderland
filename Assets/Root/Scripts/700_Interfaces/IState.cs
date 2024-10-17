using System.Collections;

public interface IState
{
    IEnumerator Play(Context context); // context を引数として受け取る
    IEnumerator Update(Context context); // context を引数として受け取る
    void Exit(); // 状態を終了するメソッド
}
