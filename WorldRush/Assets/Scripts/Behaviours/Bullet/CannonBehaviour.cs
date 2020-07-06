using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    [SerializeField]
    private Bullet cannonBullet;

    [SerializeField]
    private Transform spawningPoint;

    private float nextFire = 0.0f;
    private void Update()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + cannonBullet.FireRate;
            GameObject.Instantiate(cannonBullet.Prefab, spawningPoint.position, transform.rotation);
        }
    }
    
}
