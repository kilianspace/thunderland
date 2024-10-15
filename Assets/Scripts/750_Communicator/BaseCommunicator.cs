
public abstract class BaseCommunicator<T> : ICommunicator<T>
{
    public abstract void Transmit(T data);
    public abstract void Receive(T data);
}
