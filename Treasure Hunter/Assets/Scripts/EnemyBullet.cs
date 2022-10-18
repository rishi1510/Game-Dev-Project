using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage;
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag != "Enemy") {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, (float)0.333);
        }

        if(collision.collider.tag == "Player") {
            PlayerStats.playerStats.dealDamage(damage);
        }
    }
}
