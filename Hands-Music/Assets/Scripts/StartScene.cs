using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    private GameObject table;

    // Start is called before the first frame update
    void Start()
    {
        table = GameObject.Find("/Table");

        table.transform.position = new Vector3(table.transform.position.x, PlayerPrefs.GetFloat("table_Height"), table.transform.position.z);
    }

}
