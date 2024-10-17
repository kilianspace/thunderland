# EventManager の役割

EventManager.cs は、ゲーム内のイベントやアクションを管理するための重要な役割を果たします。これにより、ゲームのさまざまなシステム間での通信が容易になり、コードの分離が促進されます。具体的には、以下のような役割を持つことが一般的です。

## 役割

1. **イベントの発行**:  
   ゲーム内の特定のアクションや状態が発生したときに、他のシステムやオブジェクトに通知するためのイベントを発行します。

2. **イベントの登録**:  
   他のクラスやマネージャーが特定のイベントに対してリスナーとして登録できるようにします。これにより、特定のイベントが発生したときにそのイベントに関連する処理を実行できます。

3. **イベントの管理**:  
   イベントのライフサイクルを管理し、適切なタイミングでイベントを発火させたり、登録されたリスナーを呼び出したりします。

## EventManager と他のマネージャーの関係

EventManager は、一般的に他のマネージャーやシステムと連携して機能します。たとえば、以下のようなケースがあります。

- **BattleManager** が戦闘開始のイベントを発行すると、他の関連するシステム（UIや音楽など）がそのイベントを受け取り、適切なアクションを実行することができます。
- **ShopManager** がアイテム購入のイベントを発行すると、**PartyManager** はパーティーの金額を更新し、EventManager に登録されたUI要素は、現在の所持金を更新することができます。

## コード例

以下は、シンプルな EventManager の実装例です。

```csharp
using System;
using System.Collections.Generic;

public class Sample_EventManager
{
    private Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    public void Subscribe(string eventName, Action listener)
    {
        if (!eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] = null;
        }
        eventDictionary[eventName] += listener;
    }

    public void Unsubscribe(string eventName, Action listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] -= listener;
        }
    }

    public void Publish(string eventName)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName]?.Invoke();
        }
    }
}
```

## まとめ
EventManager を用いることで、ゲームの各コンポーネント間の依存関係が減り、よりモジュール化された設計が可能になります。これにより、コードの保守性や拡張性が向上し、特定のシステムが他のシステムに対して影響を与えずに機能できるようになります。したがって、EventManager は非常に重要な役割を果たすことが多いです。
