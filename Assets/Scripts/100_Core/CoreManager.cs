using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CoreManager : MonoBehaviour
{

    // Static property for the Singleton Instance
    ///////////////////////////////////
    public static CoreManager Instance { get; private set; }
    ///////////////////////////////////


    // Stored other Instances
    ///////////////////////////////////
    [SerializeField] private CoreModule _coreModule;
    [SerializeField] private InputModule _inputModule;
    [SerializeField] private FlowModule _flowModule;
    ///////////////////////////////////


    // Contexst
    ///////////////////////////////////
    [SerializeField] private CoreContext _coreContext;
    ///////////////////////////////////



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

        ///////////////////////////////////
        string dummy = "hey hey hey!";
        _coreContext = new CoreContext(dummy);
        ///////////////////////////////////
    }



}
