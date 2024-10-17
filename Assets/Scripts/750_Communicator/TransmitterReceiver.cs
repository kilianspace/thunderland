using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TransmitterReceiver<T> : BaseCommunicator<T>
{
  private T _transmitData;
  private T _receiveData;


  public override void Transmit(T data)
  {
      _transmitData = data;
      Log.Info("Data transmitted", 1);
  }

  public override void Receive(T data)
  {
      _receiveData = data;
      Log.Info("Data received", 1);
  }

  public T GetTransmitData()
  {
      return _transmitData;
  }

  public T GetReceiveData()
  {
      return _receiveData;
  }

}
