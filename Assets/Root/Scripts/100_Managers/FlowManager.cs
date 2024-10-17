using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ゲーム全体のフローを管理するクラス
public class FlowManager : MonoBehaviour
{
    private Statemachine _statemachine; // 状態遷移を管理するためのステートマシン
    private UIManager _uiManager; // UIを管理するためのUIManager
    private EventManager _eventManager; // イベントの管理を行うEventManager

    // 初期化処理
    void Start()
    {
        // UIManagerを探して取得
        _uiManager = FindObjectOfType<UIManager>();

        if (_uiManager == null)
        {
            Debug.LogError("UIManagerが見つかりません。");
            return;
        }

        // EventManager の初期化
        _eventManager = new EventManager();

        // Statemachine の初期化
        _statemachine = gameObject.AddComponent<Statemachine>();
        if (_statemachine == null)
        {
            Debug.LogError("Statemachineが正しく追加されませんでした。");
            return;
        }

        // 初期状態を設定
        _statemachine.ChangeState(new FieldState(_statemachine, _eventManager, _uiManager));
    }

    // オブジェクトが破棄される時の処理
    void OnDestroy()
    {
        // イベントリスナーの解除などが必要な場合はここに追加
    }
}
