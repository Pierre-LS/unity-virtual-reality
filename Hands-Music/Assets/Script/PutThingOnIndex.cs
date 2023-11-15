using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutThingOnIndex : MonoBehaviour
{
    public GameObject hand;//whatever has an OVR Hand script
    OVRSkeleton skeleton;
    public GameObject putThisOnIndex;
    //List<OVRBone> bones;

    // Start is called before the first frame update
    void Start()
    {
        skeleton = hand.GetComponent<OVRSkeleton>();
        //bones = new List<OVRBone>();

        foreach (OVRBone bone in skeleton.Bones)
        {
            if (bone.Id == OVRSkeleton.BoneId.Hand_IndexTip)
            {
                //bones.Add(bone);
                putThisOnIndex.transform.parent = bone.Transform;
                putThisOnIndex.transform.position = bone.Transform.position;
            }//end if
        }//end foreach
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
