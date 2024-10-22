using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // 移動速度
    private void Update()
    {
        // 入力を取得
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 新しい位置を計算
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * speed * Time.deltaTime;

        // プレイヤーを移動
        transform.position += movement;

        // プレイヤーの座標を出力
        Debug.Log("Player Position: " + transform.position);
    }

    
     private void SetPlayerLayer()
     {
         // Playerレイヤーの名前を指定
         int layerIndex = LayerMask.NameToLayer("Player");

         // Playerのレイヤーを設定
         if (layerIndex != -1)
         {
             gameObject.layer = layerIndex;
         }
     }
}
