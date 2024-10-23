using System.Collections.Generic;
using UnityEngine;



// Monster ScriptableObject class inheriting from CharacterBase
[CreateAssetMenu(fileName = "NewMonster", menuName = "Monster Data")]
public class Monster : ScriptableObject
{
    [SerializeField] private CharacterBase characterBase; // Embedding CharacterBase in Monster

    // Expose characterBase via a public property
    public CharacterBase CharacterBase
    {
        get => characterBase;
        set => characterBase = value;
    }
    
    // Additional fields specific to Monster
    [SerializeField] private string type;
    [SerializeField] private List<string> dropItems = new List<string>();
    [SerializeField] private float dropRate;
    [SerializeField] private string attribute;

    // Properties for accessing CharacterBase data
    public int ID
    {
        get => characterBase.ID;
        set => characterBase.ID = value;
    }

    public string Name
    {
        get => characterBase.Name;
        set => characterBase.Name = value;
    }

    public int HP
    {
        get => characterBase.HP;
        set => characterBase.HP = value;
    }

    public int Attack
    {
        get => characterBase.Attack;
        set => characterBase.Attack = value;
    }

    public int Defense
    {
        get => characterBase.Defense;
        set => characterBase.Defense = value;
    }

    public List<string> SpecialSkills
    {
        get => characterBase.SpecialSkills;
        set => characterBase.SpecialSkills = value;
    }

    // Properties specific to Monster
    public string Type
    {
        get => type;
        set => type = value;
    }

    public List<string> DropItems
    {
        get => dropItems;
        set => dropItems = value;
    }

    public float DropRate
    {
        get => dropRate;
        set => dropRate = value;
    }

    public string Attribute
    {
        get => attribute;
        set => attribute = value;
    }
}
