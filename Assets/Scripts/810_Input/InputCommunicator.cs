using System;
using UnityEngine;

[System.Serializable]
public class InputCommunicator : TransmitterReceiver<InputPayload> {


  // Transmit
  public override void Transmit(InputPayload data)
  {

    if (data != null)
    {
        base.Transmit(data);
        Log.Info("override Transmit");
    }
    else
    {
        Debug.LogWarning("No payload to send.");
    }
  }

  // Method to receive a new payload
  public void ReceivePayload(InputPayload data)
  {
      Receive(data);
      // Additional logic for processing received payload can be added here
  }

}
