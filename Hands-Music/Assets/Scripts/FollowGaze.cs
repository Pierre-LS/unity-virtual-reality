using UnityEngine;

public class FollowGaze : MonoBehaviour
{
    public Camera Camera2Follow;

    private float SmoothSpeed = 0.3f;
    public float distanceToHead = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    private void Update()
    {
        // make the UI always face towards the camera
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera2Follow.transform.eulerAngles.y, transform.eulerAngles.z);

        var currentPos = transform.position;

        // target is in the same direction but offsetRadius from the center
        var targetPosition = new Vector3(Camera2Follow.transform.position.x + distanceToHead*Mathf.Sin(Mathf.Deg2Rad * Camera2Follow.transform.eulerAngles.y), Camera2Follow.transform.position.y - 0.1f, Camera2Follow.transform.position.z + distanceToHead * Mathf.Cos(Mathf.Deg2Rad * Camera2Follow.transform.eulerAngles.y));

        // finally interpolate towards this position
        transform.position = Vector3.SmoothDamp(currentPos, targetPosition, ref velocity, SmoothSpeed);

        //Vector3 desiredPosition = Camera2Follow.position + offset;
        //Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, SmoothSpeed);
        //transform.position = smoothedPosition;

        //transform.LookAt(Camera2Follow);
    }
}
