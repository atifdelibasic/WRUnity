using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : BaseBulletBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.GetComponent<BaseEntityBehaviour>() != null)
        {
            if (!collision.gameObject.CompareTag(Constants.Tags.PlayerTag))
            {
                var collidedEntity = collision.gameObject.GetComponent<BaseEntityBehaviour>().Entity;
                Bullet.ApplyEffect(collidedEntity);
            }
        }
        Destroy(this.gameObject);
    }
}
