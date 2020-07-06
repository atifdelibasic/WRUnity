using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Polybrush;

public class TurtleBehaviour : BaseEntityBehaviour
{
    [SerializeField]
    private float Damage;

    [SerializeField]
    private HealthBar health;

    [SerializeField]
    private int maxH;

    private CollectablesRandomizer randomizer;
  
    private void Start()
    {
        Entity = new Enemy() { currentHealth = maxH, maxHealth = maxH };
        health.SetMaxHealth(this.Entity.maxHealth);
        randomizer = GetComponent<CollectablesRandomizer>();
    }
    private void Update()
    {
        health.SetHealth(this.Entity.currentHealth);

        if (this.Entity.currentHealth <= 0)
        {
            randomizer.Randomize();
            Destroy(this.gameObject);
            }
    }

    }
