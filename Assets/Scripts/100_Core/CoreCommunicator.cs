using System;
using UnityEngine;

[System.Serializable]
public class CoreCommunicator : TransmitterReceiver<Payload<object>> {


    // Payload
    ///////////////////////////////////
    [SerializeField] public Payload<object> Payload{ get; set; }
    ///////////////////////////////////



  // Transmit
  public override void Transmit(Payload<object> data)
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
  public void ReceivePayload(Payload<object> data)
  {
      Receive(data);
      // Additional logic for processing received payload can be added here
  }

}
