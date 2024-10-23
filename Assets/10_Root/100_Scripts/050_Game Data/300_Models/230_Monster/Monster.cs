using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(fileName = "NewMonster", menuName = "Monsters/Monster")]
public class Monster : ScriptableObject, ICombatUnit, IGameData
{
    // プロパティ
    [SerializeField] private string unitName; // nameをunitNameに変更
    [SerializeField] public int health;
    [SerializeField] public int attack;
    [SerializeField] public int defense;
    [SerializeField] public string description;

    public string Name
    {
        get { return unitName; } // プロパティを更新
        set { unitName = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public int Defense
    {
        get { return defense; }
        set { defense = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        Debug.Log($"{unitName} took {damage} damage! Remaining health: {health}");
    }

    public void AttackTarget(ICombatUnit target)
    {
        target.TakeDamage(attack);
        Debug.Log($"{unitName} attacked {target.Name} for {attack} damage!");
    }
}
