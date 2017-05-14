using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestolGrab : MonoBehaviour
{
    [SerializeField]
    private GameObject Ungrabbed;
    [SerializeField]
    private Transform UngrabbedHandler;
    [SerializeField]
    private GameObject Grabbed;



    [SerializeField]
    private float DistanceToGrab;
    [SerializeField]
    private GameObject HandPosition;


    [SerializeField] float Distance;

    [SerializeField] bool BoolPrimaryIndexTrigger;

    private void Update()
    {

        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger | OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            Distance = Vector3.Distance(HandPosition.transform.position, UngrabbedHandler.transform.position);
            if (Vector3.Distance(HandPosition.transform.position, UngrabbedHandler.transform.position) < DistanceToGrab)
            {
                Grab(true);
            }
        }
        else
        {
            Grab(false);
        }

        //Grab(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger));
        //    Debug.Log("asdasda");
        //}
        //if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        //{
        //    Grab();
        //    Debug.Log("asdasgadgfasf");
        //}
    }

    private void Grab(bool state)
    {
        Ungrabbed.SetActive(!state);
        Grabbed.SetActive(state);
    }
}
