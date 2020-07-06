using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBulletBehaviour : MonoBehaviour
{
#pragma warning disable 0649
    public Bullet Bullet;
    private Vector3 direction;
    [SerializeField]
    private string BaseTransformObjectName;
#pragma warning restore 0649

    private void Start() {
        Bullet.TravelingDirection = GameObject.Find(BaseTransformObjectName).transform;
        direction = Bullet.TravelingDirection.forward.normalized;
        }

    private void FixedUpdate()
    {
        transform.position +=  direction * Bullet.TravelingSpeed * Time.deltaTime;
    }
}
