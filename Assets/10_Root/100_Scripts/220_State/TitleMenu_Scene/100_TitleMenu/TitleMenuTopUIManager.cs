using System;
using UnityEngine;
using UnityEngine.UI; // 必要な名前空間
using TMPro; // TextMeshPro に必要な名前空間


[System.Serializable]
public class TitleMenuTopUIManager : MonoBehaviour, IUIManager
{
    // Inport Buttons
    public GameObject SelectablePanel; // UIパネルを管理するGameObject
    public TextMeshProUGUI uiText_Start;
    public TextMeshProUGUI uiText_Continue;
    public TextMeshProUGUI uiText_Config;
    public TextMeshProUGUI uiText_Quit;

    [SerializeField]public String currentItemName;

    private SelectableOption selectableOption; // SelectableOption のインスタンス

    private void Start()
    {

        Log.Info("WIIIIIDS");

        SignalPool.Instance.RegisterSignalBucket(EventContants.UI_UPDATE_TITLE_MENU_TOP);
        SignalPool.Instance.GetSignalBucket(EventContants.UI_UPDATE_TITLE_MENU_TOP)?.DropIn(EventContants.UI_UPDATE_TITLE_MENU_TOP, UpdateUI);

        // SelectableItem を初期化（1列の配列に変更）
        SelectableItem[] items = new SelectableItem[]
        {
            new SelectableItem(uiText_Start.text, uiText_Start),
            new SelectableItem(uiText_Continue.text, uiText_Continue),
            new SelectableItem(uiText_Config.text, uiText_Config),
            new SelectableItem(uiText_Quit.text, uiText_Quit)
        };

        selectableOption = new SelectableOption(items); // 1次元配列を渡す
        selectableOption.OnItemSelected += OnItemSelected; // アイテム選択時のコールバックを設定

        // 初期状態でUIをアクティブにする
        TurnOn(true);
    }

    public void TurnOn(bool shouldActive)
    {
        selectableOption.SetActive(shouldActive);
    }

    public void UpdateUI()
    {
        // UI の更新処理を追加
        UpdateSelectableText();
    }

    private void UpdateSelectableText()
    {
        // 現在選択されているアイテムに応じてテキストを更新
        uiText_Start.text = selectableOption.CurrentIndex == 0 ? "-> Start" : "Start";
        uiText_Continue.text = selectableOption.CurrentIndex == 1 ? "-> Continue" : "Continue";
        uiText_Config.text = selectableOption.CurrentIndex == 2 ? "-> Config" : "Config";
        uiText_Quit.text = selectableOption.CurrentIndex == 3 ? "-> Quit" : "Quit";

        currentItemName = selectableOption.GetCurrentItemName();

    }

    public void HandleInput()
    {
        // 上下方向の入力を処理
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectableOption.Move(-1); // 上に移動
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectableOption.Move(1); // 下に移動
        }

        // エンターキーでアイテムを選択
        if (Input.GetKeyDown(KeyCode.Return))
        {
            selectableOption.SelectItem(); // アイテムを選択
        }

        UpdateSelectableText(); // UIを更新
    }

    private void OnItemSelected(object item)
    {
        Debug.Log($"選択されたアイテム: {item}");
    }

    public void ToggleUI(bool isActive)
    {
        // UIパネルのアクティブ状態を切り替え
        SelectablePanel.SetActive(isActive);
        selectableOption.SetActive(isActive); // SelectableOption 内のアイテムのアクティブ状態も切り替え
    }
}
