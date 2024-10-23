using System; // Action に必要
using UnityEngine; // Mathf および GameObject に必要

public class SelectableOption
{
    private SelectableItem[] items; // 1D 配列でアイテムを保持
    private int currentIndex;
    public int CurrentIndex => currentIndex; // 現在のインデックスを取得


    public string GetCurrentItemName(){
        return items[currentIndex].Name;
    }




    public event Action<object> OnItemSelected; // アイテム選択時のコールバック

    public SelectableOption(SelectableItem[] selectableItems)
    {
        items = selectableItems;
        currentIndex = 0;
    }

    public void Move(int direction)
    {
        // 新しい位置を計算
        currentIndex = Mathf.Clamp(currentIndex + direction, 0, items.Length - 1);
    }

    public void SelectItem()
    {
        if (items[currentIndex] != null)
        {
            OnItemSelected?.Invoke(items[currentIndex].Item); // コールバックを発火
        }
    }



    public void SetActive(bool isActive)
    {
        // アクティブ・非アクティブを切り替える処理
        foreach (var item in items)
        {
            if (item != null)
            {
                // UI要素があればそのアクティブ状態を設定
                var uiElement = item.Item as GameObject;
                if (uiElement != null)
                {
                    uiElement.SetActive(isActive);
                }
            }
        }
    }
}
