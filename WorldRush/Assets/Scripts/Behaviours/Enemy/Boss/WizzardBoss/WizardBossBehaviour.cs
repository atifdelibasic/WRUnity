using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WizardBossBehaviour : BaseEntityBehaviour
{
    [SerializeField]
    private BoxCollider swordCollider;

    [SerializeField]
    private int attackRate;

    private Animator animator;

    [SerializeField]
    private HealthBar HealthBar;

    private Transform Player;
    private float nextAttack = 0.5f;
    private string attackMode;
    private bool isAlive = true;
    private float timeOfDeath;

    private CollectablesRandomizer randomizer;

    void Start()
    {
        Entity = new Enemy() { currentHealth = 1000, maxHealth = 1000 };
        animator = GetComponent<Animator>();
        Player = GameObject.Find("Player").transform;
        HealthBar.SetMaxHealth(Entity.maxHealth);
        randomizer = GetComponent<CollectablesRandomizer>();
    }

    void FixedUpdate()
    {
        Vector3 direction = Player.position - this.transform.position;
        if (direction.magnitude < 40)
        {
            animator.SetBool("isIdle", false);
            if (direction.magnitude <= 3f && Time.time > nextAttack)
            {
                // attack player 
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
                //swordCollider.enabled = true;
                nextAttack = Time.time + attackRate;
            }
            else
            {
                //chase Player 
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
                this.transform.Translate(Vector3.forward * Time.deltaTime * 2);
                //swordCollider.enabled = false;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isIdle", true);
        }

        CheckHealth();
    }

    private void CheckHealth()
    {
        HealthBar.SetHealth(this.Entity.currentHealth);
        float currentHealth = this.Entity.currentHealth;
        if (this.Entity.currentHealth <= 0)
        {
            if (isAlive)
            {
                timeOfDeath = Time.time + 4f;
                animator.SetTrigger("die");
                isAlive = false;
            }
            // death
            if (Time.time > timeOfDeath)
            {
                randomizer.Randomize();
                Destroy(this.gameObject);
                animator.enabled = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else if (currentHealth <= currentHealth / 2)
        {
            // get aggressive
            // add health 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    } 
}
