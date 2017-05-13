using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VR = UnityEngine.VR;

public class BaseVRInput : MonoBehaviour
{
    [SerializeField]
    float DistanceModifier = 1;
    [SerializeField]
    bool IsLeftHand;

    void Update ()
    {
        OVRInput.Controller hand = IsLeftHand ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        transform.localPosition = OVRInput.GetLocalControllerPosition(hand) * DistanceModifier;
        transform.localRotation = OVRInput.GetLocalControllerRotation(hand);
	}
}
