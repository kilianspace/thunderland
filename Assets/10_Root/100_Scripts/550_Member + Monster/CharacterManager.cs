using UnityEngine;
using System.Collections.Generic;

public class CharacterManager
{
    public Dictionary<int, CharacterBase> AllCharacters { get; private set; }

    public CharacterManager()
    {
        AllCharacters = new Dictionary<int, CharacterBase>();
    }

    public void LoadFromBook(CharacterLoader loader)
    {
        AllCharacters = loader.Characters;
    }

    public void PrintAllCharacters()
    {
        foreach (var character in AllCharacters.Values)
        {
            Debug.Log($"Character: {character.Name}, HP: {character.HP}");
        }
    }
}
