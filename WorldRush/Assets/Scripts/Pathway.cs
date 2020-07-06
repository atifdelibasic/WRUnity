using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Pathway : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 10)]
    private float Speed;

    [SerializeField]
    private GameObject[] wayPoints;

    private Transform Player;
    private Animator animator;
    private int currentI = 0;
    private float rotSpeed = 7f;
    private float accuracyWP = 0.3f;

    private void Start()
    {
        Player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        // default
        if (wayPoints.Length > 0)
            SetAnimation();
    }

    private void SetAnimation()
    {
        animator.SetBool("isWalking", true);
        animator.SetBool("isIdle", false);
    }

    private void Update()
    {
        Vector3 direction = Player.position - this.transform.position;
        direction.y = 0;
        if(wayPoints.Length > 0)
        {
            if (Vector3.Distance(wayPoints[currentI].transform.position, transform.position) <= accuracyWP)
            {
                    currentI++;
                    currentI %= wayPoints.Length;
            }

            direction = wayPoints[currentI].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(
                                      direction), rotSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * Speed);
        }
    }

}
