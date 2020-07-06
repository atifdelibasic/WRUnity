using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : BaseEntityBehaviour {
    [SerializeField]
    private HealthBar healthBar;
    new Player Entity;

    [SerializeField]
    private TextMeshProUGUI textMeshPro;

    [SerializeField]
    private TextMeshProUGUI ShieldUI;

    private bool ShieldActive = false;
    private float shieldTime = 10.0f;
    private float shieldStart = 0f;

    void Start() {
        Entity = new Player() { currentHealth = 100f, maxHealth = 100f, Score = 0 };
        healthBar.SetMaxHealth(Entity.maxHealth);
        }

    void Update() {
        checkHealth();
        checkShield();
    }

    private void checkHealth() {
        if ( this.Entity.currentHealth <= 0 ) {
            this.Entity.currentHealth = 0;
            FindObjectOfType<GameManager>().Restart();
            }

        healthBar.SetHealth(Entity.currentHealth);
        }

    public void AddScore() {
        Entity.Score++;
        textMeshPro.text = "Score: " + this.Entity.Score.ToString();
    }

    public void AddHealth(float health) {
        float addedHealth = Entity.currentHealth + health;
        if ( addedHealth > Entity.maxHealth )
            Entity.currentHealth = 100;
        else
            Entity.currentHealth = addedHealth;

        }

    public void RemoveHealth(float health) {
        if ( !ShieldActive ) {
            float removedHealth = Entity.currentHealth - health;
            if ( removedHealth < 0 )
                Entity.currentHealth = 0;
            else
                Entity.currentHealth = removedHealth;
            }
        }

    public void SetShield() {
        ShieldActive = true;
        shieldStart = Time.time;
        ShieldUI.gameObject.SetActive(ShieldActive);
    }

    private void checkShield() {
        if ( Time.time - shieldStart > shieldTime ) {
            ShieldActive = false;
            ShieldUI.gameObject.SetActive(ShieldActive);
        }
    }
    }
