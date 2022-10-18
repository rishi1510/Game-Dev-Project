using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    public HealthBar healthBar;
    public GameObject player;
    public float health, maxHealth;

    void Awake() {
        if(playerStats != null) {
            Destroy(playerStats);
        }
        else {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
        healthBar.setMaxHealth(health);
    }

    public void dealDamage(float damage) {
        health -= damage;
        healthBar.setHealth(health);
        checkDeath();
    }

    public void healCharacter(float heal) {
        health += heal;
        if(health > maxHealth) {
            health = maxHealth;
        }
        healthBar.setHealth(health);
    }

    private void checkDeath() {
        if(health <= 0) {
            Destroy(player);
        }
    }
}
