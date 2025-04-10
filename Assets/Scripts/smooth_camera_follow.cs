using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Set these in Inspector to match your background size
    public Vector2 minPosition;
    public Vector2 maxPosition;

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        
        // Clamp camera position within your background boundaries
        float clampedX = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        float clampedY = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, desiredPosition.z), smoothSpeed);
        transform.position = smoothedPosition;
    }
}
