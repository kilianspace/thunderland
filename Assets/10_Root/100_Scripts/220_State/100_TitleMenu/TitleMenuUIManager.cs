using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 必要な名前空間

public class TitleMenuUIManager : MonoBehaviour, IUIManager
{

    // Inport Buttons
    public Text SelectableText_Start;
    public Text SelectableText_Continue;
    public Text SelectableText_Config;
    public Text SelectableText_Quit;



    private void Start()
    {
        SignalPool.Instance.RegisterSignalBucket(EventContants.UI_UPDATE_TITLE_MENU_TOP);
        // StatemachineのSwitchState内でイベントリスナー登録する
        SignalPool.Instance.GetSignalBucket(EventContants.UI_UPDATE_TITLE_MENU_TOP)?.DropIn(EventContants.UI_UPDATE_TITLE_MENU_TOP, UpdateUI);
    }

    public void UpdateUI()
    {

    }


}
