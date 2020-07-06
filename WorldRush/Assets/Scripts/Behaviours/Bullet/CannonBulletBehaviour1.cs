using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBulletBehaviour1 : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;

    [SerializeField]
    private Vector3 destructionTime;

    [SerializeField]
    private int bulletDamage;

    void Update()
    {
        transform.position += direction * 10 * Time.deltaTime;
        Destroy(this.gameObject, .8f);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if(other.gameObject.GetComponent<BaseEntityBehaviour>() != null)
        {
            var collidedEntity = other.gameObject.GetComponent<PlayerBehaviour>();
            collidedEntity.RemoveHealth(10);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
