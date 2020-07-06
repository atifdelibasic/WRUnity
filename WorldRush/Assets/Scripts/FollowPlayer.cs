using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class FollowPlayer : BaseEntityBehaviour
{
    private Animator animator;
    private Transform Player;

    private bool destroy = false;

    private void Start()
    {
        Entity = new Enemy() { currentHealth = 100, maxHealth = 100 };
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Vector3 direction = Player.position - this.transform.position;

        if (direction.magnitude < 15 && direction.magnitude > 1.4f && !destroy)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);

            this.transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
        else
            animator.SetBool("isWalking", false);
    }


    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isAttacking", true);
        animator.SetBool("isWalking", false);
        destroy = true;
    }

}
