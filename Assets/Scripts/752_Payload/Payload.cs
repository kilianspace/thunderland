using System;
using UnityEngine;


public abstract class Payload
{
}


[Serializable]
public class Payload<T> : Payload
{
    [SerializeField] private T _transmitData;  // 送信データ
    [SerializeField] private T _receiveData;   // 受信データ

    // コンストラクタ
    public Payload(T transmitData)
    {
        _transmitData = transmitData;
    }

    // データを取得するためのメソッド
    public T GetTransmitData()
    {
        return _transmitData; // 送信データを返す
    }

    public T GetReceiveData()
    {
        return _receiveData; // 受信データを返す
    }

    // 受信データを設定するメソッド
    public void SetReceiveData(T receiveData)
    {
        _receiveData = receiveData; // 受信データを設定する
    }
}
