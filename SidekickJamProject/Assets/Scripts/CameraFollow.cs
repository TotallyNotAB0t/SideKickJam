using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.03f;
    [SerializeField] private Vector3 offset = new Vector3(4f, 3f, 0);
    
    //TODO limiter camera
    private void LateUpdate()
    {
        Vector3 desiredPosition;
        float velocity = Input.GetAxis("Horizontal");
        
        if (velocity < 0) desiredPosition = target.position - new Vector3(offset.x,-offset.y,offset.z);
        else if (velocity > 0) desiredPosition = target.position + offset;
        else desiredPosition = target.position + new Vector3(0, offset.y, 0);
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
