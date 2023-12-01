using System.Collections;
using UnityEngine;

public class FollowGaze_NoHeight : MonoBehaviour
{
    public Camera Camera2Follow;

    public float SmoothSpeed = 0.3f;
    public float distanceToHead = 0.3f;
    private float table_angle;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        StartCoroutine(waiter());
    }

    void OnEnable()
    {
        // Make the UI face towards the camera
        table_angle = Camera2Follow.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, table_angle, transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Interpolate towards this position
        var currentPos = transform.position;
        var targetPosition = new Vector3(Camera2Follow.transform.position.x + distanceToHead*Mathf.Sin(Mathf.Deg2Rad * table_angle), transform.position.y, Camera2Follow.transform.position.z + distanceToHead * Mathf.Cos(Mathf.Deg2Rad * table_angle));
        transform.position = Vector3.SmoothDamp(currentPos, targetPosition, ref velocity, SmoothSpeed);
    }
    IEnumerator waiter()
    {
        //Wait for 0.01 seconds
        yield return new WaitForSeconds(0.01f);
        // Make the UI face towards the camera
        table_angle = Camera2Follow.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, table_angle, transform.eulerAngles.z);
    }
}
