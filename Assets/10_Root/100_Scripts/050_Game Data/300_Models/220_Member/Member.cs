using System.Collections.Generic; // 追加
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "NewMember", menuName = "GameData/Member")]
public class Member : ScriptableObject, ICombatUnit, IGameData
{
    // プロパティ
    [SerializeField] private string name; // publicに変更
    [SerializeField] public int health;   // publicに変更
    [SerializeField] public int attack;   // publicに変更
    [SerializeField] public int defense;  // publicに変更
    [SerializeField] public string description;  // publicに変更




    public string Name
    {
        get { return name; }
        set { name = value; } // setアクセサを追加
    }
      public int Health
      {
          get { return health; }
          set { health = value; } // setアクセサを追加
      }
      public int Attack
      {
          get { return attack; }
          set { attack = value; } // setアクセサを追加
      }
      public int Defense
      {
          get { return defense; }
          set { defense = value; } // setアクセサを追加
      }

      public string Description
      {
          get { return description; }
          set { description = value; } // setアクセサを追加
      }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        Debug.Log($"{name} took {damage} damage! Remaining health: {health}");
    }

    public void AttackTarget(ICombatUnit target)
    {
        target.TakeDamage(attack);
        Debug.Log($"{name} attacked {target.Name} for {attack} damage!");
    }
}
