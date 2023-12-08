using System.Collections;
using UnityEngine;
using static UnityEngine.UI.Extensions.ContentScrollSnapHorizontal.MoveInfo;

public class StartScene : MonoBehaviour
{
    private GameObject table;
    public Camera Camera2Follow;

    private Collider MainMenu_button_collider;
    private Collider Initialize_button_collider;

    private GameObject indexTip;
    private GameObject middleTip;
    private GameObject ringTip;
    private GameObject littleTip;

    // Start is called before the first frame update
    void Start()
    {

        indexTip = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_IndexMetacarpal/L_IndexProximal/L_IndexIntermediate/L_IndexDistal/L_IndexTip");
        middleTip = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_MiddleMetacarpal/L_MiddleProximal/L_MiddleIntermediate/L_MiddleDistal/L_MiddleTip");
        ringTip = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_RingMetacarpal/L_RingProximal/L_RingIntermediate/L_RingDistal/L_RingTip");
        littleTip = GameObject.Find("/XR Interaction Hands Setup/XR Origin (XR Rig)/Camera Offset/Left Hand/Left Hand Interaction Visual/L_Wrist/L_LittleMetacarpal/L_LittleProximal/L_LittleIntermediate/L_LittleDistal/L_LittleTip");

        indexTip.GetComponent<ParticleSystem>().Stop();
        middleTip.GetComponent<ParticleSystem>().Stop();
        ringTip.GetComponent<ParticleSystem>().Stop();
        littleTip.GetComponent<ParticleSystem>().Stop();

        table = GameObject.Find("/Table");

        table.transform.position = new Vector3(table.transform.position.x, PlayerPrefs.GetFloat("table_Height") - 0.01f, table.transform.position.z);

        MainMenu_button_collider = GameObject.Find("/Table/PokeButton Main Menu/PokeCollider").GetComponent<Collider>();
        Initialize_button_collider = GameObject.Find("/Table/PokeButton Initialize/PokeCollider").GetComponent<Collider>();

        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        MainMenu_button_collider.enabled = false;
        Initialize_button_collider.enabled = false;
        //Wait for 0.7 seconds
        yield return new WaitForSeconds(0.7f);
        MainMenu_button_collider.enabled = true;
        Initialize_button_collider.enabled = true;
    }

}
