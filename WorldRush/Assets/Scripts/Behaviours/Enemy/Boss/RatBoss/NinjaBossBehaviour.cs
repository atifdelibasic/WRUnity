using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class NinjaBossBehaviour : BaseEntityBehaviour
{
    [SerializeField]
    private BoxCollider swordCollider;

    [SerializeField]
    private HealthBar HealthBar;

    [SerializeField]
    private GameObject[] bombEnemy;

    private bool boostHealth = false;
    private bool isAlive = true;

    private Animator animator;
    private Transform Player;
    private CollectablesRandomizer randomizer;

    private float nextAttack = 0.5f;
    private float attackRate = 0.8f;
    private float Speed = 2.5f;
    private float timeOfDeath;
    private float nextSpawnTime = 0.0f;
    private float enemySpawnTime = 5f;

    private string[] attackMode = { "attack01", "attack02", "attack03" };

    void Start()
    {
        Entity = new Enemy() { currentHealth = 1000, maxHealth = 1000 };
        Player = GameObject.Find("Player").transform;
        HealthBar.SetMaxHealth(Entity.maxHealth);
        animator = GetComponent<Animator>();
        randomizer = GetComponent<CollectablesRandomizer>();
    }

    void FixedUpdate()
    {
        Vector3 direction = Player.position - this.transform.position;

        if (direction.magnitude < 30 && isAlive)
        {
            if (direction.magnitude <= 3f && Time.time > nextAttack)
            {
                animator.SetBool("isWalking", false);
                DisableAttacks();

                // PHASES 1st, 2nd AND 3rd 
                AttackPlayer();
            }
            else if (direction.magnitude > 3)
            {
                Walk();
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        CheckHealth();
    }

    private void Walk()
    {
        DisableAttacks();
        animator.SetBool("isWalking", true);
        this.transform.Translate(Vector3.forward.normalized * Time.deltaTime * Speed);
    }

    private void AttackPlayer()
    {

        if (HealthPercentage(0.30f))
        {
            // PHASE 3
            animator.SetBool(attackMode[Random.Range(0, attackMode.Length)], true);
        }
        else if(HealthPercentage(0.75f))
        {
            // PHASE 2
            animator.SetBool(attackMode[Random.Range(0, attackMode.Length - 1)], true);
        }
        else
        {
            // PHASE 1
            animator.SetBool(attackMode[0], true);
        }

        nextAttack = Time.time + attackRate;
    }

    private void spawnRandomEnemy()
    {
        if (Time.time > nextSpawnTime)
        {
            var xPos = this.transform.position.x;
            var zPos = this.transform.position.z;
            GameObject.Instantiate(bombEnemy[Random.Range(0, bombEnemy.Length)],
                                             new Vector3(Random.Range(xPos, xPos + 3), 21, zPos - 3.5f), Quaternion.identity);
            nextSpawnTime = Time.time + enemySpawnTime;
        }
    }

    private bool HealthPercentage(float percentage)
    {
        return this.Entity.currentHealth <= (this.Entity.maxHealth * percentage);
    }

    private void DisableAttacks()
    {
        for (int i = 0; i < attackMode.Length; i++)
            animator.SetBool(attackMode[i], false);
    }

    private void CheckHealth()
    {
        if (HealthPercentage(0.4f) && !boostHealth)
        {
            upgradeBoss();
        }
        else
        {
            if (this.Entity.currentHealth <= 0)
            {
                DisableAttacks();
                if (isAlive)
                {
                    isAlive = false;
                    animator.SetTrigger("die");
                    timeOfDeath = Time.time + 4f;
                    //randomizer.Randomize();
                }
                // death
                if (Time.time > timeOfDeath)
                {
                    animator.enabled = false;
                    Destroy(this.gameObject);
                    FindObjectOfType<GameManager>().NextLevel();
                }
            }
        }

        UpdateHealthUI();
    }

    private void upgradeBoss()
    {
        this.gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.2f,
                                                           transform.localScale.y + 0.2f,
                                                           transform.localScale.z + 0.2f);
        this.Entity.currentHealth += Entity.maxHealth / 2;
        boostHealth = true;

        Speed += 0.5f;
        attackRate += 0.2f;
    }

    private void UpdateHealthUI()
    {
        HealthBar.SetHealth(this.Entity.currentHealth);
    }
}
