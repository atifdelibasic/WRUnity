using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlatformPath Path;

    [SerializeField]
    private float Speed = 1f;

    [SerializeField]
    private AnimationCurve Animation;

    private int CurrentI;

    private void Start()
    {
        CurrentI = 0;
        transform.position = Path.WayPoints[0];
    }

    private void Update()
    {
        var prevTarget = (CurrentI == 0) ? Path.WayPoints[Path.WayPoints.Count - 1] : Path.WayPoints[CurrentI - 1];  
        var currentTarget = Path.WayPoints[CurrentI];
        var toTarget = currentTarget - transform.position;
        var toGo = toTarget.normalized * Speed * Time.deltaTime /** Animation.Evaluate( 1- (toTarget.magnitude / Vector3.Distance(prevTarget, currentTarget)))*/;

        if(toTarget.magnitude < 0.01f || toGo.magnitude > toTarget.magnitude)
        {
            CurrentI = (CurrentI + 1) % Path.WayPoints.Count;
            toGo = toTarget;
        }

        transform.position += toGo;
    }
}
