using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreManager : MonoBehaviour
{
  // Static property for the Singleton Instance
  public static CoreManager Instance { get; private set; }

  private void Awake()
  {
    // Mainly in a case of entering a new scene
    if( Instance != null && Instance != this )
    {
      Destroy(this.gameObject);
      Debug.Log("CoreManager gameobject has got deleted");
      return;
    }

    // Set this as the only one
    Instance = this;
    Debug.Log("A new CoreManager has got created");
    DontDestroyOnLoad(this.gameObject);

  }
}
