using System;
using UnityEngine;

[System.Serializable]
public class InputCommunicator : TransmitterReceiver<InputPayload> {

  public InputPayload Payload{ get; set; }



  // Transmit
  public override void Transmit(InputPayload data)
  {

    if (Payload != null)
    {
        base.Transmit(Payload);
        Log.Info("override Transmit");
    }
    else
    {
        Debug.LogWarning("No payload to send.");
    }
  }

  // Method to receive a new payload
  public void ReceivePayload(InputPayload payload)
  {
      Receive(payload);
      // Additional logic for processing received payload can be added here
  }

}
