using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingEffect : BaseEffect
{
    [Range(1, 50)]
    public float TravelingSpeed;

    public Transform TravelingDirection;
}
