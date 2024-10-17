using System;
using UnityEngine;

[System.Serializable]
public class FlowCommunicator : TransmitterReceiver<Payload<FlowContext>> {

    // Payload
    ///////////////////////////////////
    [SerializeField] public Payload<object> Payload{ get; set; }
    ///////////////////////////////////



  // Transmit
  public override void Transmit(Payload<FlowContext> data)
  {
      if (data != null)
      {
          Log.Info("Data transmitted via Hub.");
      }
      else
      {
          Debug.LogWarning("No payload to send.");
      }
  }

  // Method to receive a new payload
  public override void Receive(Payload<FlowContext> data)
  {
      Receive(data);
      Log.Info("Payload received and processed.");
  }

}
