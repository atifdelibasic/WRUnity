using System;
using System.Numerics;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "WorldRush/Assets/Bullet", order = 1)]

public class Bullet : MovingEffect
{
    [SerializeField]
    public float FireRate = 0.5f;

    [NonSerialized]
    public int Damage = 10;

    public override void ApplyEffect(BaseEntity obj)
    {
        obj.currentHealth -= Damage;
    }
}
