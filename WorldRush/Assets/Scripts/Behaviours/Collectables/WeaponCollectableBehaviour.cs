using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeaponCollectableBehaviour : CollectableBehaviour
{
    [SerializeField]
    private Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update() {
        RotateWeaponObject();
        }

    private void OnCollisionEnter(Collision collision) {
        if ( collision.gameObject.CompareTag(Constants.Tags.PlayerTag) ) {
            
            if(bullet!=null) {
                bullet.Damage += 10;
                Destroy(gameObject);
                }
        }

     }

    public void RotateWeaponObject() {
        gameObject.transform.Rotate(0,0, 100.0f * Time.deltaTime);
        }
    }
