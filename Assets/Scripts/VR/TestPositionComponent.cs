using UnityEngine;
using UnityEngine.VR;

public class TestPositionComponent : MonoBehaviour
{
    public Transform Object;

    public bool HeadLocalRotation;
    public bool LeftHandLocalRotation;
    public bool RightHandLocalRotation;
    public bool LeftHandLocalPosition;
    public bool RightHandLocalPosition;

    public Vector3 HeadPosition;
    public Vector3 LeftHandPosition;
    public Vector3 RightHandPosition;

    // Update is called once per frame
    void Update()
    {
        if (HeadLocalRotation)
        {
            Vector3 headLocalRotation = InputTracking.GetLocalRotation(VRNode.Head).eulerAngles;

            Object.localRotation = InputTracking.GetLocalRotation(VRNode.Head);
        }

        if (LeftHandLocalRotation)
        {
            Vector3 leftHandLocalRotation = InputTracking.GetLocalRotation(VRNode.LeftHand).eulerAngles;

            Object.localRotation = InputTracking.GetLocalRotation(VRNode.LeftHand);
        }

        if (RightHandLocalRotation)
        {
            Vector3 rightHandLocalRotation = InputTracking.GetLocalRotation(VRNode.RightHand).eulerAngles;

            Object.localRotation = InputTracking.GetLocalRotation(VRNode.RightHand);
        }

        if (LeftHandLocalPosition)
        {
            Vector3 leftHandLocalPosition = InputTracking.GetLocalPosition(VRNode.LeftHand);

            Object.localPosition = InputTracking.GetLocalPosition(VRNode.LeftHand);
        }

        if (RightHandLocalPosition)
        {
            Vector3 rightHandLocalPosition = InputTracking.GetLocalPosition(VRNode.RightHand);

            Object.localPosition = InputTracking.GetLocalPosition(VRNode.RightHand);
        }

        //Vector3 headLocalRotation = InputTracking.GetLocalRotation(VRNode.Head).eulerAngles;
        //HeadPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller);
        //LeftHandPosition = OVRInput.GetControllerOrientationTracked.LeftHandLocalPosition;
       
        RightHandPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        //RightHandPosition = InputTracking.GetLocalPosition(VRNode.RightHand);
        
        //		OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick)
    }
}