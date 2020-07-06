using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Transform _bulletHolder;
    [SerializeField]
    private Transform _bulletSpawningPoint;
    [SerializeField]
    private GameObject _bullet;
#pragma warning restore 0649
    private float nextFire = 0.0f;

    public void GenerateBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + _bullet.GetComponent<BaseBulletBehaviour>().Bullet.FireRate;
            GameObject.Instantiate(_bullet, _bulletSpawningPoint.position, transform.rotation)
                .transform.SetParent(_bulletHolder);
        }
    }
}

