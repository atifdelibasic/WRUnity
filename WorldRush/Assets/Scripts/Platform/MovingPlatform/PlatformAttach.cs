using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    private void Start()
    {
        Player = GameObject.Find("Player").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        Player.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        Player.transform.parent = null;
    }
}
