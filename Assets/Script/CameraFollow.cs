using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // ตัวที่กล้องจะตาม เช่น Player
    public Vector3 offset;         // ระยะห่างกล้องจาก Player
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
