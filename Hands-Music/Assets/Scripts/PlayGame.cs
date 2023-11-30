using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    private GameObject right_palm;
    private Collider right_palm_collider;

    private GameObject table;
    private FollowGaze_NoHeight table_script;

    // Start is called before the first frame update
    void Start()
    {
        right_palm = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Right Hand/Right Hand Interaction Visual/R_Wrist/R_Palm");
        right_palm_collider = right_palm.GetComponent<Collider>();

        table = GameObject.Find ("/Table");
        table_script = table.GetComponent<FollowGaze_NoHeight>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == right_palm_collider)
        {
            table_script.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == right_palm_collider)
        {
            table_script.enabled = true;
        }
    }
}
