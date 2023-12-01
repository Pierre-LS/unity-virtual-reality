using UnityEngine;

public class CheckExtension : MonoBehaviour
{
    public GameObject Thumb;
    public bool WentExtended;
    private Collider ThumbCollider;
    private GameObject ExtendedThumb;

    private void Start()
    {
        WentExtended = true;
        ThumbCollider = Thumb.GetComponent<Collider>();

        ExtendedThumb = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/ExtendedThumb");
        ExtendedThumb.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!WentExtended && other == ThumbCollider)
        {
            ExtendedThumb.SetActive(false);
            WentExtended = true;
        }
    }
}