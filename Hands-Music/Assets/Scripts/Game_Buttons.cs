using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Game_Buttons : MonoBehaviour
{
    public UnityEvent onPress;
    public UnityEvent onRelease;

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
            onPress.Invoke();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
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
