using UnityEngine;

public class Exit_Button : MonoBehaviour
{
    private GameObject presser;
    private bool isPressed;
    private float start_timer;
    private float press_time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            start_timer = Time.time;
            presser = other.gameObject;
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser && Time.time - start_timer > press_time)
        {
            Application.Quit();
            Debug.Log("Game closed");
            isPressed = false;
        }
    }
}
