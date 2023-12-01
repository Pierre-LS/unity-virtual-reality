using UnityEngine;
using System.Collections;

public class Next_Button : MonoBehaviour
{
    public Start_Initialization main_script;

    private GameObject presser;
    private bool isPressed;
    private Collider button_collider;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        button_collider = GetComponent<Collider>();
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
            main_script.text_number++;
            isPressed = false;
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        button_collider.enabled = false;
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        button_collider.enabled = true;
    }
}
