using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempBullet : MonoBehaviour
{
    public float FlySpeed;
    public float DestroyDelay;

    [HideInInspector]
    public Rigidbody CachedRigidbody;

    void Awake()
    {
        CachedRigidbody = this.GetComponent<Rigidbody>();
    }
}
