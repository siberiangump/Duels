using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    [SerializeField]
    private Transform WhatToFollow;

    private void Update()
    {
        transform.position = WhatToFollow.position;
    }
}
