using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BasePlayer : NetworkBehaviour, IShooter, IShootable
{
    private Vector3 InitialPostion;

    public override void OnStartLocalPlayer()
    {
        InitialPostion = this.transform.position;
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CmdShoot();
        }
    }

    public void GetShot()
    {
        Debug.LogWarning("get shot");

        this.GetComponentInChildren<Renderer>().material.color = Color.red;
    }

    public void Shoot()
    {
        Debug.LogWarning("shoot");

        BasePlayer[] players = GameObject.FindObjectsOfType<BasePlayer>();

        foreach (var player in players)
        {
            if (player != this)
            {
                player.RpcGetShot();
            }
        }
    }

    [Command]
    private void CmdShoot()
    {
        Shoot();
    }

    [ClientRpc]
    private void RpcGetShot()
    {
        GetShot();
    }
}
