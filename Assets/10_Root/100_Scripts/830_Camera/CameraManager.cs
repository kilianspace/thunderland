using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player; // プレイヤーキャラクターのTransform
    public Vector3 offset;   // カメラのオフセット

    void LateUpdate()
    {
        // カメラの位置を追従
        // transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        //
        // // デバッグ用：カメラの位置とプレイヤーの位置をログに出力
        // Debug.Log("Camera Position: " + transform.position);
        // Debug.Log("Player Position: " + player.position);
    }
}
