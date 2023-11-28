using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LightUp : MonoBehaviour
{
    public Material TouchedColor;
    public GameObject Thumb;
    public GameObject Wrist;
    public CheckExtension checkExtension;
    public AudioSource FingerSound;
    
    Material UntouchedColor;
    Renderer ObjectRenderer;
    Collider ThumbCollider;

    // Start is called before the first frame update
    void Start()
    {
        ObjectRenderer = GetComponent<Renderer>();
        UntouchedColor = ObjectRenderer.material;
        ThumbCollider = Thumb.GetComponent<Collider>();
        FingerSound = GetComponent<AudioSource>();

        if (ObjectRenderer == null)
        {
            Debug.Log("Renderer component not found on the GameObject.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == ThumbCollider && checkExtension.WentExtended)
        {
            ObjectRenderer.material = TouchedColor;
            ScoreUpdate.instance.IncreaseScore(1);
            FingerSound.Play();
            checkExtension.WentExtended = false;
            Debug.Log("The thumb is extended:" + checkExtension.WentExtended);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == ThumbCollider)
        {
            ObjectRenderer.material = UntouchedColor;
        }
    }
}
