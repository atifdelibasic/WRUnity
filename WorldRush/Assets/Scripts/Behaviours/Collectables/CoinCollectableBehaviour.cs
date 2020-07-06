using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectableBehaviour : CollectableBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RotateObject();
    }

    private void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.CompareTag(Constants.Tags.PlayerTag) ) {
            collision.gameObject.GetComponent<PlayerBehaviour>().AddScore();
            Destroy(gameObject);
            }
        }
    }
