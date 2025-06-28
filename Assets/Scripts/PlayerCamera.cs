using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target; // this will be the player
    public float smoothSpeed = 0.05f;
    public Vector3 offset;

    public Vector2 minBounds;
    public Vector2 maxBounds;

    private float cameraHalfHeight;
    private float cameraHalfWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraHalfHeight = Camera.main.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
       
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        Vector3 endPos = target.position + offset;
        float clampedX = Mathf.Clamp(endPos.x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
        float clampedY = Mathf.Clamp(endPos.y, minBounds.y + cameraHalfHeight, maxBounds.y - cameraHalfHeight);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, endPos.z);
        //transform.position = Vector3.Lerp(transform.position, clampedPosition, smoothSpeed);

        Vector3 velocity = Vector3.zero; // Declare this at the class level
        transform.position = Vector3.SmoothDamp(transform.position, clampedPosition, ref velocity, smoothSpeed);
    }
}
