using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BasePlayer : NetworkBehaviour, IShooter, IShootable
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void GetShot()
    {
        Debug.LogWarning("GetShot");
    }

    public void Shoot()
    {
        BasePlayer[] players = GameObject.FindObjectsOfType<BasePlayer>();

        foreach (var player in players)
        {
            if (player != this)
            {
                player.GetShot();
            }
        }
    }

    [Command]
    private void CmdShoot()
    {
        Shoot();
    }
}
