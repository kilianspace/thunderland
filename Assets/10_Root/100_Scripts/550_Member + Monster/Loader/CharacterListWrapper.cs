using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Character list wrapper for JSON serialization
[System.Serializable]
public class CharacterListWrapper
{
    public List<CharacterBase> Characters; // List of CharacterBase
}
