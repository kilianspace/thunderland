using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要
using System.Collections;
using System;

[System.Serializable]
public class StateContext
{

    // Required Property
    //////////////////////////////////
    [SerializeField] private Statemachine _statemachine;
    public Statemachine Statemachine
    {
        get { return _statemachine; }
        set { _statemachine = value; }
    }
    //////////////////////////////////

    // SignalPool
    //////////////////////////////////
    [SerializeField] private SignalPool _signalPool;
    public SignalPool SignalPool
    {
        get { return _signalPool; }
        set { _signalPool = value; }
    }
    //////////////////////////////////



    // [OPTION] UI Manager
    //////////////////////////////////
    [SerializeField] private IUIManager _uiManager;
    public IUIManager UIManager
    {
        get { return _uiManager; }
        set { _uiManager = value; }
    }
    public StateContext WithOptionalUIManager(IUIManager uiManager)
    {
        _uiManager = uiManager;
        return this;
    }
    //////////////////////////////////



    // Required Property
    //////////////////////////////////
    [SerializeField] private GameDataManager _gameDataManager;
    public GameDataManager GameDataManager
    {
        get { return _gameDataManager; }
        set { _gameDataManager = value; }
    }
    public StateContext WithOptionaGameDataManager(GameDataManager gameDataManager)
    {
        _gameDataManager = gameDataManager;
        return this;
    }
    //////////////////////////////////





    // Static Factory Method
    //////////////////////////////////
    public static StateContext Create(
        Statemachine statemachine,
        SignalPool signalPool
    )
    {
        return new StateContext(statemachine, signalPool);
    }
    //////////////////////////////////



    // Private Cnstructor
    //////////////////////////////////
    private StateContext(
        Statemachine statemachine,
        SignalPool signalPool,
        UIManager uiManager = null,
        IGameData  gameData = null
    ){

        _statemachine = statemachine;
        _signalPool = signalPool;

    }
    //////////////////////////////////

}
