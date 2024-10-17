using System;
using UnityEngine;

[System.Serializable]
public class InputCommunicator : TransmitterReceiver<Payload<object>>
{
    // Payload
    ///////////////////////////////////
    [SerializeField] public Payload<object> Payload { get; set; }
    ///////////////////////////////////


    // Transmit
    public void Transmit(Payload<InputContext> data) // Payload<InputContext>を受け取る
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
    public override void Receive(Payload<object> data)
    {
        // 受信したPayload<object>を処理する
        if (data != null)
        {
            // Payload<object>からInputContextを取り出す
            var inputContext = data.GetTransmitData() as Payload<InputContext>; // GetTransmitData()を使用

            if (inputContext != null)
            {
                // 受け取ったデータがInputContextであれば処理する
                Log.Info("Received Payload<InputContext>.");
                // ここで必要な処理を実施
            }
            else
            {
                Log.Warning("Received payload is not of type InputContext.");
            }
        }
        else
        {
            Log.Warning("No payload received.");
        }
    }
}
