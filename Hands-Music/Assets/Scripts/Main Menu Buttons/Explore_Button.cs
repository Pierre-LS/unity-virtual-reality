using System.Collections;
using UnityEngine;

public class Explore_Button : MonoBehaviour
{
    public GameObject forest_button_prefab;
    public GameObject ocean_button_prefab;
    public GameObject back_button_prefab;

    private Transform menu_buttons;
    private GameObject explore_button;
    private Collider explore_button_collider;
    private GameObject exit_button;
    private Collider exit_button_collider;
    private GameObject forest_button;
    private Collider forest_button_collider;
    private GameObject ocean_button;
    private Collider ocean_button_collider;
    private GameObject back_button;
    private Collider back_button_collider;

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

            explore_button = menu_buttons.Find("Explore Button(Clone)").gameObject;
            explore_button_collider = GameObject.Find("/Buttons/Explore Button(Clone)/PokeCollider").GetComponent<Collider>();
            explore_button_collider.enabled = false;
            Destroy(explore_button, pop_time + 0.3f);

            exit_button = menu_buttons.Find("Exit Button(Clone)").gameObject;
            exit_button_collider = GameObject.Find("/Buttons/Exit Button(Clone)/PokeCollider").GetComponent<Collider>();
            exit_button_collider.enabled = false;
            Destroy(exit_button, pop_time + 0.3f);

            forest_button = Instantiate(forest_button_prefab, explore_button.transform.localPosition, Quaternion.Euler(5, 20, 0));
            forest_button.transform.SetParent(menu_buttons, false);
            forest_button_collider = GameObject.Find("/Buttons/Forest Button(Clone)/PokeCollider").GetComponent<Collider>();

            ocean_button = Instantiate(ocean_button_prefab, explore_button.transform.localPosition, Quaternion.Euler(5, -20, 0));
            ocean_button.transform.SetParent(menu_buttons, false);
            ocean_button_collider = GameObject.Find("/Buttons/Ocean Button(Clone)/PokeCollider").GetComponent<Collider>();

            back_button = Instantiate(back_button_prefab, explore_button.transform.localPosition, explore_button.transform.localRotation);
            back_button.transform.SetParent(menu_buttons, false);
            back_button_collider = GameObject.Find("/Buttons/Back Button(Clone)/PokeCollider").GetComponent<Collider>();

            StartCoroutine(waiter());

            change_button = false;
        }

        if (elapsed_time < pop_time)
        {
            forest_button.transform.localScale = Vector3.Lerp(no_scale, full_scale, elapsed_time / pop_time);
            forest_button.transform.localPosition = Vector3.Lerp(forest_button.transform.localPosition, new Vector3(0.2f, 0.05f, 0), elapsed_time / pop_time);

            ocean_button.transform.localScale = Vector3.Lerp(no_scale, full_scale, elapsed_time / pop_time);
            ocean_button.transform.localPosition = Vector3.Lerp(ocean_button.transform.localPosition, new Vector3(-0.2f, 0.05f, 0), elapsed_time / pop_time);

            back_button.transform.localScale = Vector3.Lerp(no_scale, full_scale, elapsed_time / pop_time);

            explore_button.transform.localScale = Vector3.Lerp(explore_button.transform.localScale, no_scale, elapsed_time / pop_time);

            exit_button.transform.localScale = Vector3.Lerp(exit_button.transform.localScale, no_scale, elapsed_time / pop_time);
            exit_button.transform.localPosition = Vector3.Lerp(exit_button.transform.localPosition, explore_button.transform.localPosition, elapsed_time / pop_time);

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
        forest_button_collider.enabled = false;
        ocean_button_collider.enabled = false;
        back_button_collider.enabled = false;
        //Wait for 0.7 seconds
        yield return new WaitForSeconds(0.7f);
        forest_button_collider.enabled = true;
        ocean_button_collider.enabled = true;
        back_button_collider.enabled = true;
    }
}