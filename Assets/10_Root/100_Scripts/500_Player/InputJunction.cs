using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// プレイヤーの入力を処理するクラス
public class InputJunction
{

    private static InputJunction _instance; // シングルトンのインスタンス
   // ゲームの入力に関する設定（例えば、InputSystemで定義されたアクションマッピングなど）
   private GameInputs _inputs;

   // 単一のInputAction（特定のボタンやアクションのイベントを定義）
   private InputAction _inputAction;

   // ゲームの現在の状態（ゲーム内での進行状況など）
   private GameState _gameState;


   // プライベートコンストラクタでインスタンス生成を防ぐ
   private InputJunction(GameInputs inputs)
   {
       _inputs = inputs;
       _ensemble = new InputActionEnsemble(_inputs);
   }


   // シングルトンインスタンスの取得
   public static InputJunction Instance(GameInputs inputs = null)
   {
       if (_instance == null && inputs != null)
       {
           _instance = new InputJunction(inputs);
       }
       return _instance;
   }



   // 複数のInputActionとそれに対応するKeyActionBinderをまとめる内部クラス
   private class InputActionEnsemble
   {
      private GameInputs _gameInputs; // ゲームの入力設定
      private Dictionary<InputAction, KeyActionBinder> _ensemble; // InputActionとそれに対応するKeyActionBinderを保持する辞書

      // コンストラクタ。ゲームの入力設定を受け取り、辞書を初期化
      public InputActionEnsemble(GameInputs gameInputs)
      {
         _ensemble = new Dictionary<InputAction, KeyActionBinder>(); // 新しい辞書を作成
         _gameInputs = gameInputs; // 入力設定を代入
      }

      // InputActionとそれに対応するKeyActionBinderを辞書に追加するメソッド
      public void AddKeyActionBinderWithInputAction(InputAction inputAction, KeyActionBinder binder)
      {
         _ensemble.Add(inputAction, binder); // InputActionとそのバインダーを辞書に追加
      }

      // InputActionに対応するKeyActionBinderを取得するメソッド
      public KeyActionBinder GetBinder(InputAction inputAction)
      {
         // 指定されたInputActionに対応するKeyActionBinderを辞書から取得。見つからなければnullを返す
         if (_ensemble.TryGetValue(inputAction, out KeyActionBinder binder))
         {
            return binder; // 見つかった場合、バインダーを返す
         }
         return null; // 見つからなければnullを返す
      }
   }

   // 特定のコントローラーキーに対してアクションをバインドするクラス
   private class KeyActionBinder
   {
      private GameInputs _gameInputs; // ゲームの入力設定
      private GameState _gameState; // ゲームの状態
      private Dictionary<ControllerKey, Action<InputAction.CallbackContext>> _ensemble; // キーとアクションの対応関係を保持する辞書

      // コンストラクタ。ゲームの入力設定と状態を受け取り、辞書を初期化
      public KeyActionBinder(GameInputs gameInputs, GameState gameState)
      {
         _gameInputs = gameInputs; // 入力設定を代入
         _gameState = gameState; // ゲームの状態を代入
         _ensemble = new Dictionary<ControllerKey, Action<InputAction.CallbackContext>>(); // 新しい辞書を作成
      }

      // 特定のコントローラーキーに対するアクションを追加するメソッド
      public void AddCallback(ControllerKey controllerKey, Action<InputAction.CallbackContext> inputAction)
      {
         _ensemble.Add(controllerKey, inputAction); // コントローラーキーとアクションを辞書に追加
      }

      // コントローラーキーに対応するアクションを取得するメソッド
      public Action<InputAction.CallbackContext> GetCallback(ControllerKey controllerKey)
      {
         _ensemble.TryGetValue(controllerKey, out Action<InputAction.CallbackContext> callback); // キーに対応するアクションを取得
         return callback; // アクションを返す
      }
   }

   private InputActionEnsemble _ensemble; // InputActionとそれに対応するバインダーを保持するクラス
   private KeyActionBinder _binder; // 特定のアクションに対するバインダー

   // コンストラクタ。ゲームの入力、特定のアクション、ゲームの状態、各種コントローラーのボタンを受け取る
   public InputJunction(
      GameInputs inputs,
      InputAction inputAction,
      GameState gameState,
      // 各ボタン（オプションで受け取る。渡されなければnullになる）
      ControllerKey? cross = null,
      ControllerKey? circle = null,
      ControllerKey? square = null,
      ControllerKey? triangle = null,
      // D-Pad
      ControllerKey? dPadUp = null,
      ControllerKey? dPadDown = null,
      ControllerKey? dPadLeft = null,
      ControllerKey? dPadRight = null,
      // 肩ボタン
      ControllerKey? l1 = null,
      ControllerKey? r1 = null,
      // トリガー
      ControllerKey? l2 = null,
      ControllerKey? r2 = null,
      // ジョイスティック
      ControllerKey? leftStickX = null,
      ControllerKey? leftStickY = null,
      ControllerKey? rightStickX = null,
      ControllerKey? rightStickY = null,
      // ジョイスティック押し込み
      ControllerKey? leftStickPress = null,
      ControllerKey? rightStickPress = null,
      // タッチパッド
      ControllerKey? touchpadClick = null,
      // オプション＆シェアボタン
      ControllerKey? options = null,
      ControllerKey? share = null,
      // PlayStationボタン
      ControllerKey? psButton = null,
      // タッチパッドのスワイプ
      ControllerKey? touchpadSwipeUp = null,
      ControllerKey? touchpadSwipeDown = null,
      ControllerKey? touchpadSwipeLeft = null,
      ControllerKey? touchpadSwipeRight = null,
      // ジャイロセンサー/モーションセンサー
      ControllerKey? gyro = null,
      ControllerKey? accelerometer = null
   )
   {
      _inputs = inputs; // ゲームの入力設定を保存
      _inputAction = inputAction; // 特定のアクションを保存
      _gameState = gameState; // ゲームの状態を保存

      // 新しいInputActionEnsembleインスタンスを作成
      _ensemble = new InputActionEnsemble(_inputs);
      // 新しいKeyActionBinderインスタンスを作成
      _binder = new KeyActionBinder(_inputs, _gameState);

      // クロスボタンが指定されている場合、そのボタンに対するコールバックをバインダーに追加
      if (cross.HasValue)
      {
         _binder.AddCallback(cross.Value, OnCrossPressed);
      }

      // 他のボタンに対するコールバックもここで追加可能...

      // KeyActionBinderをInputActionEnsembleに追加
      _ensemble.AddKeyActionBinderWithInputAction(_inputAction, _binder);
   }

   // クロスボタンが押された際に実行されるアクション
   private void OnCrossPressed(InputAction.CallbackContext context)
   {
      Debug.Log("Cross button pressed"); // ログに「クロスボタンが押された」と表示
   }

   // ゲーム状態に応じてコールバックを登録するメソッド
   public void RegisterCallbacksForGameState()
   {
      // InputActionに対応するKeyActionBinderを取得
      KeyActionBinder binder = _ensemble.GetBinder(_inputAction);
      if (binder != null)
      {
         // クロスボタンのアクションを取得して、ゲーム入力に登録
         Action<InputAction.CallbackContext> crossCallback = binder.GetCallback(ControllerKey.Cross);
         if (crossCallback != null)
         {
            _inputs.SELECT.Cross.performed += crossCallback; // クロスボタンが押されたときのイベントを登録
         }
         // 他のアクションも同様に登録可能...
      }
   }

   // ゲーム状態に応じてコールバックを解除するメソッド
   public void UnregisterCallbacksForGameState()
   {
      // InputActionに対応するKeyActionBinderを取得
      KeyActionBinder binder = _ensemble.GetBinder(_inputAction);
      if (binder != null)
      {
         // クロスボタンのアクションを取得して、登録を解除
         Action<InputAction.CallbackContext> crossCallback = binder.GetCallback(ControllerKey.Cross);
         if (crossCallback != null)
         {
            _inputs.SELECT.Cross.performed -= crossCallback; // クロスボタンのイベントを解除
         }
         // 他のアクションも同様に解除可能...
      }
   }
}
