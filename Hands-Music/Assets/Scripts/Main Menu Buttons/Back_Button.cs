using UnityEngine;
using System.Collections;

public class Back_Button : MonoBehaviour
{
    public GameObject explore_button_prefab;
    public GameObject exit_button_prefab;

    private Transform menu_buttons;
    private GameObject explore_button;
    private GameObject exit_button;
    private GameObject forest_button;
    private GameObject ocean_button;
    private GameObject back_button;

    private Vector3 full_scale = new Vector3(1f, 1f, 1f);
    private Vector3 no_scale = new Vector3(0.0001f, 0.0001f, 0.0001f);
    private float pop_time = 3f;
    private float elapsed_time;

    private GameObject presser;
    private bool isPressed;
    private bool change_button;

    // Start is called before the first frame update
    void Start()
    {
        menu_buttons = transform.parent.parent;
        isPressed = false;
        change_button = false;
        elapsed_time = pop_time + 1f;
    }

    private void Update()
    {
        if (change_button == true)
        {
            elapsed_time = 0;

            explore_button = Instantiate(explore_button_prefab, new Vector3(0, -0.2f, 0), Quaternion.Euler(5, 0, 0));
            explore_button.transform.SetParent(menu_buttons, false);

            exit_button = Instantiate(exit_button_prefab, new Vector3(0, -0.2f, 0), Quaternion.Euler(5, 0, 0));
            exit_button.transform.SetParent(menu_buttons, false);

            back_button = menu_buttons.Find("Back Button(Clone)").gameObject;
            Destroy(back_button, pop_time);

            forest_button = menu_buttons.Find("Forest Button(Clone)").gameObject;
            Destroy(forest_button, pop_time);

            ocean_button = menu_buttons.Find("Ocean Button(Clone)").gameObject;
            Destroy(ocean_button, pop_time);

            change_button = false;
        }

        if (elapsed_time < pop_time)
        {
            explore_button.transform.localScale = Vector3.Lerp(no_scale, full_scale, elapsed_time / pop_time);

            exit_button.transform.localScale = Vector3.Lerp(no_scale, full_scale, elapsed_time / pop_time);
            exit_button.transform.localPosition = Vector3.Lerp(exit_button.transform.localPosition, new Vector3(0.25f, -0.3f, -0.07f), elapsed_time / pop_time);
            exit_button.transform.localEulerAngles = Vector3.Lerp(exit_button.transform.localEulerAngles, new Vector3(20, 32, -8), elapsed_time / pop_time);

            back_button.transform.localScale = Vector3.Lerp(explore_button.transform.localScale, no_scale, elapsed_time / pop_time);

            forest_button.transform.localScale = Vector3.Lerp(forest_button.transform.localScale, no_scale, elapsed_time / pop_time);
            forest_button.transform.localPosition = Vector3.Lerp(forest_button.transform.localPosition, new Vector3(0, -0.2f, 0), elapsed_time / pop_time);
            forest_button.transform.localEulerAngles = Vector3.Lerp(forest_button.transform.localEulerAngles, new Vector3(5, 0, 0), elapsed_time / pop_time);

            ocean_button.transform.localScale = Vector3.Lerp(ocean_button.transform.localScale, no_scale, elapsed_time / pop_time);
            ocean_button.transform.localPosition = Vector3.Lerp(ocean_button.transform.localPosition, new Vector3(0, -0.2f, 0), elapsed_time / pop_time);
            ocean_button.transform.localEulerAngles = Vector3.Lerp(ocean_button.transform.localEulerAngles, new Vector3(5, 0, 0), elapsed_time / pop_time);

            elapsed_time += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            presser = other.gameObject;
            isPressed = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            change_button = true;
            isPressed = false;
        }
    }
}
