public interface IModule<T>
{
  ICommunicator<T> Communicator { get; set; }
}
