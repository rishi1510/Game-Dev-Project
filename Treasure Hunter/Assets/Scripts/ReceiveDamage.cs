using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReceiveDamage : MonoBehaviour
{
    public float health, maxHealth;
    void Start()
    {
        health = maxHealth;
    }

    public void dealDamage(float damage) {
        health -= damage;
        checkDeath();
    }

    private void checkDeath() {
        if(health <= 0) {
            gameObject.GetComponent<LootBag>().instantiateLoot(transform.position);
            
            Destroy(gameObject);
        }
    }
}