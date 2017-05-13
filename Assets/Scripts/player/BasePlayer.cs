using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BasePlayer : NetworkBehaviour, IShooter, IShootable
{
    [SerializeField] TempBullet BulletPrefab;
    [SerializeField] Transform CameraAnchor;

    public override void OnStartLocalPlayer()
    {
        SetupCamera();
    }

    private void SetupCamera()
    {
        Camera camera = Camera.main;

        camera.transform.parent = CameraAnchor;
        camera.transform.localPosition = Vector3.zero;
        camera.transform.localEulerAngles = Vector3.zero;
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
        this.GetComponentInChildren<Renderer>().material.color = Color.red;
    }

    public void Shoot()
    {
        SpawnBullet(); 

        BasePlayer enemyPlayer = GetEnemyPlayer();

        if (enemyPlayer != null)
        {
            enemyPlayer.RpcGetShot();
        }
    }

    private BasePlayer GetEnemyPlayer()
    {
        BasePlayer[] players = GameObject.FindObjectsOfType<BasePlayer>();

        foreach (var player in players)
        {
            if (player != this)
            {
                return player;
            }
        }

        return null;
    }

    private void SpawnBullet()
    {
        TempBullet bullet = GameObject.Instantiate(BulletPrefab);
        bullet.transform.position = CameraAnchor.position;  // needs to be value of a gun

        bullet.CachedRigidbody.velocity = Vector3.left * bullet.FlySpeed;

        Destroy(bullet.gameObject, bullet.DestroyDelay);
        NetworkServer.Spawn(bullet.gameObject);
    }

#region Server commands
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
#endregion
}
