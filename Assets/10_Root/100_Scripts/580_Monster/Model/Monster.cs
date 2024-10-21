using System.Collections.Generic; // Required for List<T>

// Monster class implementing CharacterBase
[System.Serializable]
public class Monster : CharacterBase
{
    public string Type { get; set; } // Nullable string
    public List<string> DropItems { get; set; } = new List<string>(); // Always initialized
    public float DropRate { get; set; } // Non-nullable float
    public string Attribute { get; set; } // Nullable string
}
