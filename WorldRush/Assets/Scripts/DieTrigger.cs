using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameManager>().Restart();
    }
}
