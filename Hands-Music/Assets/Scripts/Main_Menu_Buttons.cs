using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Main_Menu_Button : MonoBehaviour
{
    public UnityEvent onPress;
    public UnityEvent onRelease;

    GameObject presser;
    bool isPressed;

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
        if (other.gameObject ==  presser)
        {
            onRelease.Invoke();
            isPressed=false;
        }
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void ExploreButton()
    {
        SceneManager.LoadSceneAsync("Simulation");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync("Start Menu");
    }
}
