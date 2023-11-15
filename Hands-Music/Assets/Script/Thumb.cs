using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thumb : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audio;

    void Start(){
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(1, 0, 0);
        Debug.Log("START");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "indexFinger")
        {
            UnityEngine.Debug.Log("ENTER");
            //audio.Play();
        }
    }
}
