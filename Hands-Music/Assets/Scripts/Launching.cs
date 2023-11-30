using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Launching : MonoBehaviour
{
    public GameObject explore_button_prefab;
    public GameObject exit_button_prefab;

    private Transform menu_buttons;
    private GameObject explore_button;
    private GameObject explore_button_collider;
    private GameObject exit_button;
    private GameObject exit_button_collider;
    // Start is called before the first frame update
    void Start()
    {
        menu_buttons = GameObject.Find("Buttons").transform;

        explore_button = Instantiate(explore_button_prefab, new Vector3(0, -0.2f, 0), Quaternion.Euler(31, 0, 0));
        explore_button.transform.SetParent(menu_buttons, false);
        explore_button_collider = GameObject.Find("/Buttons/Explore Button(Clone)/PokeCollider");

        exit_button = Instantiate(exit_button_prefab, new Vector3(0.25f, -0.3f, -0.07f), Quaternion.Euler(41, 29, 0));
        exit_button.transform.SetParent(menu_buttons, false);
        exit_button_collider = GameObject.Find("/Buttons/Exit Button(Clone)/PokeCollider");

        StartCoroutine(waiter());

        if (PlayerPrefs.GetFloat("table_Height") == 0)
        {
            SceneManager.LoadSceneAsync("Initialization");
        }
    }


    IEnumerator waiter()
    {
        explore_button_collider.GetComponent<Collider>().enabled = false;
        exit_button_collider.GetComponent<Collider>().enabled = false;
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        explore_button_collider.GetComponent<Collider>().enabled = true;
        exit_button_collider.GetComponent<Collider>().enabled = true;
    }
}
