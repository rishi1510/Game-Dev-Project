using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ReceiveDamage : MonoBehaviour
{
    public float health, maxHealth;

    public GameObject deathEffect;

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

            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            if(GetComponent<SpriteRenderer>().flipX == true) {
                effect.GetComponent<SpriteRenderer>().flipX = true;
            }

            Destroy(gameObject);
            Destroy(effect, (float)0.75);
        }
    }
}