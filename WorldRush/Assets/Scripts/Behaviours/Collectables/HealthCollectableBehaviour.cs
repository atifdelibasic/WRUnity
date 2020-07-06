using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthCollectableBehaviour : CollectableBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }

    private void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.CompareTag(Constants.Tags.PlayerTag) ) {
            collision.gameObject.GetComponent<PlayerBehaviour>().AddHealth(10);
            Destroy(gameObject);
            }
           
        }
    }
