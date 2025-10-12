using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Update()
    {
        // カメラの方向を向く
        transform.LookAt(Camera.main.transform);
    }
}