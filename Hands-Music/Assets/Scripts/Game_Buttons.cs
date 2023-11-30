using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game_Buttons : MonoBehaviour
{
    public UnityEvent onPress;
    public UnityEvent onRelease;

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
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser && Time.time - start_timer > press_time)
        {
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync("Start Menu");
    }

    public void ReInitializeButton()
    {
        SceneManager.LoadSceneAsync("Initialization");
    }
}
