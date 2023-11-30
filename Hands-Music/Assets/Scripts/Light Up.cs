using UnityEngine;

public class LightUp : MonoBehaviour
{
    public Material TouchedColor;
    public GameObject Thumb;
    public GameObject Wrist;
    public CheckExtension checkExtension;
    public ScoreUpdate score_script;

    Material UntouchedColor;
    Renderer ObjectRenderer;
    Collider ThumbCollider;

    // Start is called before the first frame update
    void Start()
    {
        ObjectRenderer = GetComponent<Renderer>();
        UntouchedColor = ObjectRenderer.material;
        ThumbCollider = Thumb.GetComponent<Collider>();

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
            score_script.currentScore++;
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
