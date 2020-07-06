using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
   
    public void RotateObject()
    {
        gameObject.transform.Rotate(0,100.0f * Time.deltaTime, 0);
    }
}
