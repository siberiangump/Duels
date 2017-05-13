using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestolGrab : MonoBehaviour
{
    [SerializeField]
    private GameObject Ungrabbed;
    [SerializeField]
    private GameObject Grabbed;
    [SerializeField]
    private float DistanceToGrab;
    [SerializeField]
    private GameObject HandPosition;

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0)
        {
            Grab();
            Debug.LogError("!");
        }
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0)
        {
            Grab();
            Debug.LogError("&!");
        }
    }
    
    private void Grab()
    {
        Ungrabbed.SetActive(false);
        Grabbed.SetActive(true);
    }
}
