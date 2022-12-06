using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage;
    public GameObject popup;
    
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.tag != "Enemy") {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, (float)0.333);
        }

        if(collision.collider.tag == "Player" && collision.collider.GetComponent<MovePlayer>().isDashing == false) {
            PlayerStats.playerStats.dealDamage(damage);
            popup.GetComponent<DamagePopup>().Create(transform.position, damage, 2);
        }
    }
}
