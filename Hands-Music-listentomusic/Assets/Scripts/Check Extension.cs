using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckExtension : MonoBehaviour
{
    public GameObject Thumb;
    public bool WentExtended;
    Collider ThumbCollider;

    private void Start()
    {
        WentExtended = true;
        ThumbCollider = Thumb.GetComponent<Collider>();
        Debug.Log("The thumb is extended:" + WentExtended);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!WentExtended && other == ThumbCollider)
        {
            WentExtended = true;
            Debug.Log("The thumb is extended:" + WentExtended);
        }
    }
}