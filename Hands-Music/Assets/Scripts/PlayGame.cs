using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    private GameObject right_palm;
    private Collider right_palm_collider;

    private GameObject table;
    private FollowGaze_NoHeight table_script;

    private GameObject hand_position;
    private GameObject wrist_position;

    private Vector3 velocity1 = Vector3.zero;
    private Vector3 velocity2 = Vector3.zero;
    private Vector3 velocity3 = Vector3.zero;
    private Vector3 velocity4 = Vector3.zero;
    private Vector3 velocity5 = Vector3.zero;
    private Vector3 velocity6 = Vector3.zero;
    private Vector3 velocity7 = Vector3.zero;
    private Vector3 velocity8 = Vector3.zero;

    private GameObject palm_position;
    private BoxCollider palm_position_collider;

    private AudioSource background_music;
    private AudioSource game_music;

    public string objectType;
    private Object[] objectsListArray;

    private float elapsed_time;
    private float game_start_time;
    private bool started_game;
    private bool get_squished;

    public List<float> finger1_trigger;
    public List<float> finger2_trigger;
    public List<float> finger3_trigger;
    public List<float> finger4_trigger;

    private int finger1_num;
    private int finger2_num;
    private int finger3_num;
    private int finger4_num;

    private Transform indexTip;
    private Transform middleTip;
    private Transform ringTip;
    private Transform littleTip;

    // Start is called before the first frame update
    void Start()
    {
        right_palm = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Right Hand/Right Hand Interaction Visual/R_Wrist/R_Palm");
        right_palm_collider = right_palm.GetComponent<Collider>();

        indexTip = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_IndexMetacarpal/L_IndexProximal/L_IndexIntermediate/L_IndexDistal/L_IndexTip").transform;
        middleTip = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_MiddleMetacarpal/L_MiddleProximal/L_MiddleIntermediate/L_MiddleDistal/L_MiddleTip").transform;
        ringTip = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_RingMetacarpal/L_RingProximal/L_RingIntermediate/L_RingDistal/L_RingTip").transform;
        littleTip = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_LittleMetacarpal/L_LittleProximal/L_LittleIntermediate/L_LittleDistal/L_LittleTip").transform;

        table = GameObject.Find ("/Table");
        table_script = table.GetComponent<FollowGaze_NoHeight>();

        hand_position = GameObject.Find("/Table/RightHand/RightHand");
        wrist_position = GameObject.Find("/Table/RightHand/R_Wrist");

        palm_position = GameObject.Find("/Table/RightHand/R_Wrist/R_Palm");
        palm_position_collider = palm_position.GetComponent<BoxCollider>();
        palm_position_collider.size = new Vector3(0.07f, 0.04f, 0.1f);

        background_music = GameObject.Find("/Background Music").GetComponent<AudioSource>();
        game_music = GameObject.Find("/Game Music").GetComponent<AudioSource>();

        //Store all Gameobjects in an array like this
        objectsListArray = Resources.LoadAll(objectType, typeof(GameObject));

        started_game = false;
        get_squished  = false;

        finger1_num = 0;
        finger2_num = 0;
        finger3_num = 0;
        finger4_num = 0;
    }

    private void Update()
    {
        if (elapsed_time > 2f)
        {
            if (!started_game)
            {
                finger1_num = 0;
                finger2_num = 0;
                finger3_num = 0;
                finger4_num = 0;

                background_music.Pause();
                game_music.Play();
                game_start_time = Time.time;
                started_game = true;
            }

            if (Time.time - game_start_time > finger1_trigger[finger1_num] - 3f)
            {
                GameObject objectToAppear1 = (GameObject)objectsListArray[Random.Range(0, objectsListArray.Length)];
                GameObject newObject1 = Instantiate(objectToAppear1, Vector3.zero, Quaternion.identity);
                newObject1.transform.SetParent(indexTip, true);
                newObject1.transform.localPosition = new Vector3(0f, -0.1f, 0f);
                newObject1.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                finger1_num++;
            }

            if (Time.time - game_start_time > finger2_trigger[finger2_num] - 3f)
            {
                GameObject objectToAppear2 = (GameObject)objectsListArray[Random.Range(0, objectsListArray.Length)];
                GameObject newObject2 = Instantiate(objectToAppear2, Vector3.zero, Quaternion.identity);
                newObject2.transform.SetParent(middleTip, true);
                newObject2.transform.localPosition = new Vector3(0f, -0.1f, 0f);
                newObject2.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                finger2_num++;
            }

            if (Time.time - game_start_time > finger3_trigger[finger3_num] - 3f)
            {
                GameObject objectToAppear3 = (GameObject)objectsListArray[Random.Range(0, objectsListArray.Length)];
                GameObject newObject3 = Instantiate(objectToAppear3, Vector3.zero, Quaternion.identity);
                newObject3.transform.SetParent(ringTip, true);
                newObject3.transform.localPosition = new Vector3(0f, -0.1f, 0f);
                newObject3.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                finger3_num++;
            }

            if (Time.time - game_start_time > finger4_trigger[finger4_num] - 3f)
            {
                GameObject objectToAppear4 = (GameObject)objectsListArray[Random.Range(0, objectsListArray.Length)];
                GameObject newObject4 = Instantiate(objectToAppear4, Vector3.zero, Quaternion.identity);
                newObject4.transform.SetParent(littleTip, true);
                newObject4.transform.localPosition = new Vector3(0f, -0.1f, 0f);
                newObject4.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                finger4_num++;
            }

            if (Time.time - game_start_time > 5*60)
            {
                elapsed_time = 0f;
                started_game = false;
                game_music.Stop();
                background_music.Play();
            }
        }

        if (get_squished == true)
        {
            palm_position_collider.size = Vector3.SmoothDamp(palm_position_collider.size, new Vector3(palm_position_collider.size.x, 4f, palm_position_collider.size.z), ref velocity1, 0.8f);
            palm_position_collider.center = Vector3.SmoothDamp(palm_position_collider.center, new Vector3(palm_position_collider.center.x, 0.015f, palm_position_collider.center.z), ref velocity2, 0.8f);

            wrist_position.transform.localScale = Vector3.SmoothDamp(wrist_position.transform.localScale, new Vector3(1f, 0.01f, 1f), ref velocity3, 0.8f);
            wrist_position.transform.localPosition = Vector3.SmoothDamp(wrist_position.transform.localPosition, new Vector3(wrist_position.transform.localPosition.x, -0.015f, wrist_position.transform.localPosition.z), ref velocity4, 0.8f);
        }

        if (get_squished == false)
        {
            palm_position_collider.size = Vector3.SmoothDamp(palm_position_collider.size, new Vector3(palm_position_collider.size.x, 0.04f, palm_position_collider.size.z), ref velocity5, 0.8f);
            palm_position_collider.center = Vector3.SmoothDamp(palm_position_collider.center, new Vector3(palm_position_collider.center.x, 0f, palm_position_collider.center.z), ref velocity6, 0.8f);

            wrist_position.transform.localScale = Vector3.SmoothDamp(wrist_position.transform.localScale, new Vector3(1f, 1f, 1f), ref velocity7, 0.8f);
            wrist_position.transform.localPosition = Vector3.SmoothDamp(wrist_position.transform.localPosition, new Vector3(wrist_position.transform.localPosition.x, 0f, wrist_position.transform.localPosition.z), ref velocity8, 0.8f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == right_palm_collider)
        {
            elapsed_time = 0f;
            table_script.enabled = false;

            hand_position.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(14f,71f,191f, 1f) * 5);
            get_squished = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == right_palm_collider)
        {
            elapsed_time += Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == right_palm_collider)
        {
            elapsed_time = 0f;
            table_script.enabled = true;

            hand_position.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(14f, 71f, 191f, 1f) * 0);
            get_squished = false;

            started_game = false;
            game_music.Stop();
            background_music.Play();
        }
    }
}
