using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesRandomizer : MonoBehaviour
{
    [SerializeField]
    public GameObject[] collectables;

    public void Randomize() {
        var position = Random.Range(0, collectables.Length);
        Instantiate(collectables[position], new Vector3(transform.position.x,2,transform.position.z), Quaternion.identity);
        
        }

}
