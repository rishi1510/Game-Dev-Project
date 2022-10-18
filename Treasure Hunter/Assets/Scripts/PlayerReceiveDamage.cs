using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceiveDamage : MonoBehaviour
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
            Destroy(gameObject);
        }
    }
}