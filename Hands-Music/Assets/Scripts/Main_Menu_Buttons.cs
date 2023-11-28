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

    private Transform menu_buttons;
    private GameObject explore_button;
    private GameObject exit_button;
    private GameObject forest_button;
    private GameObject ocean_button;
    private GameObject back_button;

    private GameObject presser;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        menu_buttons = transform.parent.gameObject.transform.parent;
        explore_button = menu_buttons.Find("Explore Button").gameObject;
        exit_button = menu_buttons.Find("Exit Button").gameObject;
        forest_button = menu_buttons.Find("Forest Button").gameObject;
        ocean_button = menu_buttons.Find("Ocean Button").gameObject;
        back_button = menu_buttons.Find("Back Button").gameObject;
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

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
    public void ExploreButton()
    {
        explore_button.SetActive(false);
        exit_button.SetActive(false);
        forest_button.SetActive(true);
        ocean_button.SetActive(true);
        back_button.SetActive(true);
    }
    
    public void ForestButton()
    {
        SceneManager.LoadSceneAsync("Simulation");
    }

    public void OceanButton()
    {
        SceneManager.LoadSceneAsync("Simulation");
    }

    public void BackButton()
    {
        explore_button.SetActive(true);
        exit_button.SetActive(true);
        forest_button.SetActive(false);
        ocean_button.SetActive(false);
        back_button.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync("Start Menu");
    }
}
