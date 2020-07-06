using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShell : MonoBehaviour
{
    [SerializeField]
    private float Damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Constants.Tags.PlayerTag))
        {
            if(other.gameObject.GetComponent<BaseEntityBehaviour>() != null)
            {
                var collidedEntity = other.gameObject.GetComponent<PlayerBehaviour>();
                collidedEntity.RemoveHealth(Damage);
            }
        }
    }
}
