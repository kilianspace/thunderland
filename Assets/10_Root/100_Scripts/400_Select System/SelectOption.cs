using System;

public class SelectOption
{
    private object[,] items; // 任意のアイテムを格納できるobject型の2次元配列
    private int currentRow;  // 現在選択されている行
    private int currentCol;  // 現在選択されている列

    public SelectOption(int rows, int cols)
    {
        items = new object[rows, cols]; // rows x cols のサイズで配列を初期化
        currentRow = 0;
        currentCol = 0;
    }

    // アイテムを設定するメソッド
    public void SetItem(int row, int col, object item)
    {
        if (row >= 0 && row < items.GetLength(0) && col >= 0 && col < items.GetLength(1))
        {
            items[row, col] = item;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Row or Column is out of range.");
        }
    }

    // カーソルを上に移動する
    public void MoveUp()
    {
        currentRow = (currentRow - 1 + items.GetLength(0)) % items.GetLength(0);
    }

    // カーソルを下に移動する
    public void MoveDown()
    {
        currentRow = (currentRow + 1) % items.GetLength(0);
    }

    // カーソルを左に移動する
    public void MoveLeft()
    {
        currentCol = (currentCol - 1 + items.GetLength(1)) % items.GetLength(1);
    }

    // カーソルを右に移動する
    public void MoveRight()
    {
        currentCol = (currentCol + 1) % items.GetLength(1);
    }

    // 現在選択されているアイテムを取得する
    public object GetSelectedItem()
    {
        return items[currentRow, currentCol];
    }

    // 現在の選択位置を表示する（デバッグ用）
    public void DisplayCurrentSelection()
    {
        Console.WriteLine($"Currently selected position: ({currentRow}, {currentCol})");
        Console.WriteLine($"Selected item: {GetSelectedItem()?.ToString() ?? "null"}");
    }
}
