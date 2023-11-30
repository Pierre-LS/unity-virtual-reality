using UnityEngine;

public class FollowGaze_NoHeight : MonoBehaviour
{
    public Camera Camera2Follow;

    public float SmoothSpeed = 0.3f;
    public float distanceToHead = 0.3f;

    private Vector3 velocity1 = Vector3.zero;
    private Vector3 velocity2 = Vector3.zero;

    private void Start()
    {
        // Make the UI always face towards the camera
        var currentAng = transform.eulerAngles;
        var targetAngle = new Vector3(transform.eulerAngles.x, Camera2Follow.transform.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(Vector3.SmoothDamp(currentAng, targetAngle, ref velocity1, SmoothSpeed));
    }

    // Update is called once per frame
    private void Update()
    {
        // Interpolate towards this position
        var currentPos = transform.position;
        var targetPosition = new Vector3(Camera2Follow.transform.position.x + distanceToHead*Mathf.Sin(Mathf.Deg2Rad * Camera2Follow.transform.eulerAngles.y), transform.position.y, Camera2Follow.transform.position.z + distanceToHead * Mathf.Cos(Mathf.Deg2Rad * Camera2Follow.transform.eulerAngles.y));
        transform.position = Vector3.SmoothDamp(currentPos, targetPosition, ref velocity2, SmoothSpeed);
    }
}
