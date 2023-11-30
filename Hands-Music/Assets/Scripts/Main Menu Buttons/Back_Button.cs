using UnityEngine;
using System.Collections;

public class Back_Button : MonoBehaviour
{
    public GameObject explore_button_prefab;
    public GameObject exit_button_prefab;

    private Transform menu_buttons;
    private GameObject explore_button;
    private GameObject explore_button_collider;
    private GameObject exit_button;
    private GameObject exit_button_collider;
    private GameObject forest_button;
    private GameObject ocean_button;
    private GameObject back_button;

    private Vector3 full_scale = new Vector3(1f, 1f, 1f);
    private Vector3 no_scale = new Vector3(0.0001f, 0.0001f, 0.0001f);
    private float pop_time = 0.5f;
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
        elapsed_time = pop_time + 0.1f;
    }

    private void Update()
    {
        if (change_button == true)
        {
            elapsed_time = 0;

            back_button = menu_buttons.Find("Back Button(Clone)").gameObject;
            Destroy(back_button, pop_time);

            forest_button = menu_buttons.Find("Forest Button(Clone)").gameObject;
            Destroy(forest_button, pop_time);

            ocean_button = menu_buttons.Find("Ocean Button(Clone)").gameObject;
            Destroy(ocean_button, pop_time);

            explore_button = Instantiate(explore_button_prefab, back_button.transform.localPosition, back_button.transform.localRotation);
            explore_button.transform.SetParent(menu_buttons, false);
            explore_button_collider = GameObject.Find("/Buttons/Explore Button(Clone)/PokeCollider");

            exit_button = Instantiate(exit_button_prefab, back_button.transform.localPosition, Quaternion.Euler(41, 29, 0));
            exit_button.transform.SetParent(menu_buttons, false);
            exit_button_collider = GameObject.Find("/Buttons/Exit Button(Clone)/PokeCollider");

            StartCoroutine(waiter());

            change_button = false;
        }

        if (elapsed_time < pop_time)
        {
            explore_button.transform.localScale = Vector3.Lerp(no_scale, full_scale, elapsed_time / pop_time);

            exit_button.transform.localScale = Vector3.Lerp(no_scale, full_scale, elapsed_time / pop_time);
            exit_button.transform.localPosition = Vector3.Lerp(exit_button.transform.localPosition, new Vector3(0.25f, -0.3f, -0.07f), elapsed_time / pop_time);

            back_button.transform.localScale = Vector3.Lerp(back_button.transform.localScale, no_scale, elapsed_time / pop_time);

            forest_button.transform.localScale = Vector3.Lerp(forest_button.transform.localScale, no_scale, elapsed_time / pop_time);
            forest_button.transform.localPosition = Vector3.Lerp(forest_button.transform.localPosition, explore_button.transform.localPosition, elapsed_time / pop_time);

            ocean_button.transform.localScale = Vector3.Lerp(ocean_button.transform.localScale, no_scale, elapsed_time / pop_time);
            ocean_button.transform.localPosition = Vector3.Lerp(ocean_button.transform.localPosition, explore_button.transform.localPosition, elapsed_time / pop_time);

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
