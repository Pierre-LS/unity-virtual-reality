using System.Collections;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    private GameObject table;
    public Camera Camera2Follow;

    private Collider MainMenu_button_collider;
    private Collider Initialize_button_collider;

    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.Find("/Table");

        table.transform.position = new Vector3(table.transform.position.x, PlayerPrefs.GetFloat("table_Height") - 0.01f, table.transform.position.z);

        MainMenu_button_collider = GameObject.Find("/Table/PokeButton Main Menu/PokeCollider").GetComponent<Collider>();
        Initialize_button_collider = GameObject.Find("/Table/PokeButton Initialize/PokeCollider").GetComponent<Collider>();

        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        MainMenu_button_collider.enabled = false;
        Initialize_button_collider.enabled = false;
        //Wait for 0.7 seconds
        yield return new WaitForSeconds(0.7f);
        MainMenu_button_collider.enabled = true;
        Initialize_button_collider.enabled = true;
    }

}
