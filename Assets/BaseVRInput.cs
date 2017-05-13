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
    [SerializeField]
    Vector3 EulerCorrelation;

    void Update ()
    {
        OVRInput.Controller hand = IsLeftHand ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
        transform.localPosition = (OVRInput.GetLocalControllerPosition(hand)) * DistanceModifier;
        if (EulerCorrelation.sqrMagnitude > 0)
            transform.localRotation = OVRInput.GetLocalControllerRotation(hand) * Quaternion.Euler(EulerCorrelation);
	}
}
