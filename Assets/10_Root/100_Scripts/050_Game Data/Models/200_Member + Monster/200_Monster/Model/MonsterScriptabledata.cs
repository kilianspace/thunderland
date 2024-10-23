using UnityEngine;

[CreateAssetMenu(fileName = "NewMonster", menuName = "Monster Data")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public int health;
    public int attackPower;
}
