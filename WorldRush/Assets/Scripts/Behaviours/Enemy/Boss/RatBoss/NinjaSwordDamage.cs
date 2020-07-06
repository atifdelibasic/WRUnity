using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSwordDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<BaseEntityBehaviour>() != null)
            {
                var collidedEntity = other.gameObject.GetComponent<PlayerBehaviour>();
                collidedEntity.RemoveHealth(10);
            }
        }
    }
}
