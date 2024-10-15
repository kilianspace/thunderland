
public class InputModule : BaseModule<InputPayload>
{

  // Pass over "manager" using Constructor
  public InputModule(IManager manager) : base(manager){}

 private InputCommunicator _inputCommunicator;


  protected void Awake()
  {
    _inputCommunicator = new InputCommunicator();
    Communicator = _inputCommunicator;
      // Write here when you need something to be initialized
  }

  protected override ICommunicator<InputPayload> CreateCommunicator()
  {
      return new InputCommunicator();
  }

  public void ProcessInput(InputPayload inputPayload)
 {
     _inputCommunicator.Transmit(inputPayload);
 }

}
