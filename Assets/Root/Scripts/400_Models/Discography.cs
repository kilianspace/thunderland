using UnityEngine;

public class DiscographyModel
{
    public Album[] albums;

    public DiscographyModel()
    {
        albums = new Album[]
        {
            new Album { name = "JUSTICE" },
            new Album { name = "Revolution" },
            new Album { name = "Nostalgia" },
            new Album { name = "太陽の少年" },
            new Album { name = "Bless" },
            new Album { name = "Honesto" },
            new Album { name = "Remind" }
        };
    }

    public void ShowAlbumNames()
    {
        foreach (var album in albums)
        {
            Debug.Log(album.name);
        }
    }
}

public class Album
{
    public string name; // アルバム名
}
