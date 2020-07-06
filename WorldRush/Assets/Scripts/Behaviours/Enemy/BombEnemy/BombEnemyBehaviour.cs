using System;
using System.Security.Cryptography;
using UnityEngine;

public class BombEnemyBehaviour : BaseEntityBehaviour
{
    [SerializeField]
    private float collisionDamage;

    [SerializeField]
    private float explosionDamage;

    [SerializeField]
    private HealthBar healthbar;

    [SerializeField]
    [Range(0.1f, 5f)]
    private float damageArea;


    private CollectablesRandomizer randomizer;
    private Animator animator;
    private Transform Player;
    private bool detonationStarted = false;
    private float detonationBegin;
    private float timer = 1.3f;
    private bool animStarted = false;

    private void Start()
    {
        Entity = new Enemy() { currentHealth = 100, maxHealth = 100};
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player").transform;
        randomizer = GetComponent<CollectablesRandomizer>();
        healthbar.SetMaxHealth(Entity.maxHealth);
        }

    private void Update() {
        Attack();
        CheckHelath();
        }

    private void CheckHelath() {
        healthbar.SetHealth(this.Entity.currentHealth);
        if ( this.Entity.currentHealth <= 0 ) {
            randomizer.Randomize();
            Destroy(this.gameObject);
            }
        }

    private void Attack()
    {
        if (detonationStarted && (Time.time - detonationBegin) >= 0.7f)
        {
            if ( Vector3.Distance(Player.position, this.transform.position) <= damageArea )
                FindObjectOfType<PlayerBehaviour>().RemoveHealth(explosionDamage);

            animStarted = true;
            detonationStarted = false;
        }

        if (animStarted && (Time.time - detonationBegin) >= timer)
        {
            Destroy(this.gameObject);
            animStarted = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.Tags.PlayerTag))
        {
            if (!animStarted)
                Detonate();
        }
    }

    private void Detonate()
    {
        detonationBegin = Time.time;
        detonationStarted = true;
        animStarted = true;
        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag(Constants.Tags.PlayerTag) )
            collision.gameObject.GetComponent<PlayerBehaviour>().RemoveHealth(collisionDamage);

    }

    


    }
