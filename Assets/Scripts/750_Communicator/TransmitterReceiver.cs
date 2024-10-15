using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TransmitterReceiver<T> : BaseCommunicator<T>
{
  private T _data;

  public override void Transmit(T data)
  {
      _data = data;
      Debug.Log("Data transmitted: " + data);
  }

  public override void Receive(T data)
  {
      _data = data;
      Debug.Log("Data received: " + data);
  }

  public T GetData()
  {
      return _data;
  }
}
