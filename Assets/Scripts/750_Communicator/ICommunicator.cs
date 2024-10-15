public interface ICommunicator<T>
{
  void Transmit(T data);
  void Receive(T data);
}
