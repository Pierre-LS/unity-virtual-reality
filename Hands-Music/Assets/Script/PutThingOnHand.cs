using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutThingOnHand : MonoBehaviour
{
    public GameObject hand;//whatever has an OVR Hand script
    OVRSkeleton skeleton;
    public GameObject putThisOnHand;
    //List<OVRBone> bones;

    // Start is called before the first frame update
    void Start()
    {
        skeleton = hand.GetComponent<OVRSkeleton>();
        //bones = new List<OVRBone>();

        foreach (OVRBone bone in skeleton.Bones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_ThumbTip)
            {
                //bones.Add(bone);
                putThisOnHand.transform.parent = bone.Transform;
                putThisOnHand.transform.position = bone.Transform.position;
            }//end if
        }//end foreach
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
