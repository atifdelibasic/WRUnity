using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    private GameObject healthBar;
    private void Start()
    {
        healthBar = GameObject.Find("BossHealth");
        healthBar.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        healthBar.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
