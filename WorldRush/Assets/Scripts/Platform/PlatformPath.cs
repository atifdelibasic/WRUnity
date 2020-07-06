using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlatformPath : MonoBehaviour
{
    public List<Vector3> WayPoints;

    private void Start()
    {
        Refresh();
    }
    private void OnDrawGizmos()
    {
        Refresh();
        Gizmos.color = Color.black;
        for (int i = 0; i < WayPoints.Count; i++)
        {
            Gizmos.DrawSphere(WayPoints[i], 0.1f);
            if (i == 0)
                Gizmos.DrawLine(WayPoints[i], WayPoints[WayPoints.Count - 1]);
            else
                Gizmos.DrawLine(WayPoints[i], WayPoints[i - 1]);
        }
    }
    private void OnTransformChildrenChanged()
    {
        Refresh();
    }
    public void Refresh()
    {
        if (WayPoints == null)
            WayPoints = new List<Vector3>();
        WayPoints.Clear();

        foreach (var childTransform in GetComponentsInChildren<Transform>())
        {
            if (transform == childTransform)
                continue;
            WayPoints.Add(childTransform.position);
        }
    }
}
