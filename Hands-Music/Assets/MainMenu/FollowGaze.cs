using UnityEngine;

public class FollowGaze : MonoBehaviour
{
    public Transform Camera2Follow;

    private float SmoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(-0.3714488f, 1.045249f, 0.06647553f);
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    private void Update()
    {
        Vector3 desiredPosition = Camera2Follow.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, SmoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(Camera2Follow);
    }
}
