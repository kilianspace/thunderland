using System.Collections.Generic;
using UnityEngine;


public interface ICombatUnit
{
    string Name { get; }
    int Health { get; }
    int Attack { get; }
    int Defense { get; }


    string Description{ get; }// 説明文


    // キャラクターの状態やアクションに関連するメソッド
    void TakeDamage(int damage);
    void AttackTarget(ICombatUnit target);
}
