using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBossProjectile : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<BaseEntityBehaviour>() != null)
            {
                var collidedEntity = collision.gameObject.GetComponent<PlayerBehaviour>();
                collidedEntity.RemoveHealth(10);
            }
        }
    }
}
