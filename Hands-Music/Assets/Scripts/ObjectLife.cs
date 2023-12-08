using System.Collections.Generic;
using UnityEngine;

public class ObjectLife : MonoBehaviour
{
    private Vector3 targetScale;
    private CheckExtension checkExtension;
    private GameObject scorer;
    private List<Vector3> FreePositions_List;

    private Collider ThumbCollider;
    private GameObject ExtendedThumb;

    private Vector3 velocity1 = Vector3.zero;
    private Vector3 velocity2 = Vector3.zero;
    private Vector3 velocity3 = Vector3.zero;

    private float start_time;
    private float score;
    private Vector3 target_location;
    private bool touched = false;

    // Start is called before the first frame update
    void Start()
    {
        checkExtension = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/Left Extended Collider").GetComponent<CheckExtension>();
        scorer = GameObject.Find("/Scorer");
        FreePositions_List = scorer.GetComponent<ObjectPositions>().FreePositions;

        ThumbCollider = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_ThumbMetacarpal/L_ThumbProximal/L_ThumbDistal/L_ThumbTip").GetComponent<Collider>();
        ExtendedThumb = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/ExtendedThumb");

        targetScale = new Vector3(1f, 1f, 1f);
        transform.localScale = Vector3.zero;

        start_time = Time.time;
        score = 0f;
        touched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!touched)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity1, 3f);
            if (Time.time - start_time > 5f)
            {
                transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.zero, ref velocity2, 0.3f);
                Destroy(gameObject, 0.3f);
            }
        }

        if (touched)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.one, ref velocity3, 1f);
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
            scorer.GetComponent<ScoreUpdate>().currentScore += score;

            ExtendedThumb.SetActive(true);
            checkExtension.WentExtended = false;

            touched = true;

            GetComponentInParent<ParticleSystem>().Play();

            GetComponent<Collider>().enabled = false;

            transform.SetParent(GameObject.Find("/Terrain").transform, false);

            target_location = (Vector3)FreePositions_List[Random.Range(0, FreePositions_List.Count)];

            transform.localPosition = target_location;
            transform.localRotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
            transform.localScale = Vector3.zero;

            FreePositions_List.Remove(target_location);
        }
    }
}
