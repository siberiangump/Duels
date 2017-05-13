using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMover : MonoBehaviour
{
    [SerializeField] private float Speed;

    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Speed, Space.Self);
    }
}
