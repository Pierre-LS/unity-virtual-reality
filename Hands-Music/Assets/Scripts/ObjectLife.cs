using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLife : MonoBehaviour
{
    private Vector3 targetScale;
    private CheckExtension checkExtension;
    private ScoreUpdate score_script;

    private Collider ThumbCollider;
    private GameObject ExtendedThumb;

    private Vector3 velocity1 = Vector3.zero;
    private Vector3 velocity2 = Vector3.zero;

    private float start_time;
    private float score;
    private bool disappear;

    // Start is called before the first frame update
    void Start()
    {
        checkExtension = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/Left Extended Collider").GetComponent<CheckExtension>();
        score_script = GameObject.Find("/Scorer").GetComponent<ScoreUpdate>();
        ThumbCollider = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_ThumbMetacarpal/L_ThumbProximal/L_ThumbDistal/L_ThumbTip").GetComponent<Collider>();
        ExtendedThumb = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/ExtendedThumb");

        targetScale = new Vector3(2f, 2f, 2f);
        transform.localScale = Vector3.zero;
        Destroy(gameObject, 5f);

        start_time = Time.time;
        score = 0f;
        disappear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disappear)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity1, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == ThumbCollider && checkExtension.WentExtended)
        {
            if (Time.time - start_time <= 3f)
            {
                score = (Time.time - start_time) / 3f;
            }
            if (Time.time - start_time > 3f)
            {
                score = (-(Time.time - start_time) / 2f) + 2.5f;
            }
            score_script.currentScore += score;

            ExtendedThumb.SetActive(true);
            checkExtension.WentExtended = false;

            disappear = true;
            transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.zero, ref velocity2, 0.3f);
            Destroy(gameObject, 0.3f);
        }
    }
}
