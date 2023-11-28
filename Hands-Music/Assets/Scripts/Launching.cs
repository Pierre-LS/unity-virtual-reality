using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launching : MonoBehaviour
{
    public GameObject explore_button_prefab;
    public GameObject exit_button_prefab;

    private Transform menu_buttons;
    private GameObject explore_button;
    private GameObject exit_button;
    // Start is called before the first frame update
    void Start()
    {
        menu_buttons = GameObject.Find("Buttons").transform;

        explore_button = Instantiate(explore_button_prefab, new Vector3(0, -0.2f, 0), Quaternion.Euler(5, 0, 0));
        explore_button.transform.SetParent(menu_buttons, false);

        exit_button = Instantiate(exit_button_prefab, new Vector3(0.25f, -0.3f, -0.07f), Quaternion.Euler(20, 32, -8));
        exit_button.transform.SetParent(menu_buttons, false);
    }
}
