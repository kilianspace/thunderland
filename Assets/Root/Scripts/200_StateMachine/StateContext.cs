// ゲームを通じてタイトルからエンディングまで引き継がれる
public class StateContext
{

    // Required Property
    //////////////////////////////////
    private Statemachine _statemachine;
    public Statemachine Statemachine
    {
        get { return _statemachine; }
        set { _statemachine = value; }
    }
    //////////////////////////////////

    // SignalPool
    //////////////////////////////////
    private SignalPool _signalPool;
    public SignalPool SignalPool
    {
        get { return _signalPool; }
        set { _signalPool = value; }
    }
    //////////////////////////////////

    // Required Property
    //////////////////////////////////
    private IGameData _gameData;
    public IGameData GameData
    {
        get { return _gameData; }
        set { _gameData = value; }
    }
    //////////////////////////////////

    // Private Cnstructor
    //////////////////////////////////
    private StateContext(
        Statemachine statemachine,
        SignalPool signalPool,
        IGameData  gameData = null)
    {

        _statemachine = statemachine;
        _signalPool = signalPool;
        _gameData = gameData;
    }
    //////////////////////////////////

    // Static Factory Method
    //////////////////////////////////
    public static StateContext Create(
        Statemachine statemachine,
        SignalPool signalPool,
        IGameData  gameData = null
    )
    {
        return new StateContext(statemachine, signalPool, gameData);
    }
    //////////////////////////////////

    // [OPTION] UI Manager
    //////////////////////////////////
    public IUIManager _uiManager;
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

}
