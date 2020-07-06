using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BaseEntityBehaviour>() != null)
        {
            if (other.gameObject.CompareTag(Constants.Tags.PlayerTag))
            {
                var collidedEntity = other.gameObject.GetComponent<PlayerBehaviour>();
                collidedEntity.RemoveHealth(10);
            }
        }
    }
}
