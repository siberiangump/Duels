using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{

    [SerializeField] Transform FirstPoint;
    [SerializeField] Transform SecondaryPoint;

    [SerializeField] LineRenderer LinePrefab;
    [SerializeField] GameObject Pulia;

    LineRenderer Line;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger | OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Shot();
        }
    }

    public void Shot()
    {

        GameObject go = Instantiate(Pulia);
        go.transform.position = SecondaryPoint.position;
        go.transform.rotation = SecondaryPoint.rotation * Quaternion.Euler(new Vector3(0, 90, 0));
        return;
        Vector3 dirToTarget = (SecondaryPoint.position - FirstPoint.position).normalized;
        float dstToTarget = 100;//Vector3.Distance(FirstPoint.position, SecondaryPoint.position);

        Ray r = new Ray(FirstPoint.position, dirToTarget);

        if (Line != null)
            Destroy(Line.gameObject);

        Line = Instantiate(LinePrefab.gameObject).GetComponent<LineRenderer>();
        Line.SetPositions(new Vector3[2] { FirstPoint.position, r.GetPoint(1000*100)});
        //if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget))
        //{
        //    visibleTargets.Add(target);
        //}

    }

}
