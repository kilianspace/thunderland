using System;
using UnityEngine;

[System.Serializable]
public class CoreCommunicator : TransmitterReceiver<CorePayload> {

  public CorePayload Payload{ get; set; }



  // Transmit
  public override void Transmit(CorePayload data)
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
  public void ReceivePayload(CorePayload payload)
  {
      Receive(payload);
      // Additional logic for processing received payload can be added here
  }

}
