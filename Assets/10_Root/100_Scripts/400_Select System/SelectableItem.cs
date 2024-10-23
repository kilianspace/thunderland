public class SelectableItem
{
    public string Name { get; private set; }
    public object Item { get; private set; }

    // コンストラクタで Name と任意のオブジェクトを受け取る
    public SelectableItem(string name, object item)
    {
        Name = name;
        Item = item; // ここで任意のオブジェクトを受け入れる
    }
}
