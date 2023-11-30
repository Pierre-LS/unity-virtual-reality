using UnityEngine;
using System.Collections;

public class Previous_Button : MonoBehaviour
{
    public Start_Initialization main_script;

    private GameObject presser;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
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
            main_script.text_number--;
            isPressed = false;
            StartCoroutine(waiter());
        }
    }

    IEnumerator waiter()
    {
        GetComponent<Collider>().enabled = false;
        //Wait for 2 seconds
        yield return new WaitForSeconds(2);
        GetComponent<Collider>().enabled = true;
    }
}
