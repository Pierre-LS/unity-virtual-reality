using UnityEngine;
using UnityEngine.SceneManagement;

public class Ocean_Button : MonoBehaviour
{
    private GameObject presser;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            presser = other.gameObject;
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            SceneManager.LoadSceneAsync("Simulation");
            isPressed = false;
        }
    }
}
