using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private Transform Player;
    
    private float LookDist = 20f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        Player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        LookRotation();
    }
   
    private void LookRotation()
    {
        Vector3 direction = Player.position - this.transform.position;
        if (Vector3.Distance(Player.position, this.transform.position) < LookDist)
        {
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, 
                                      Quaternion.LookRotation(direction), 4f * Time.deltaTime);
        }
    }
}
