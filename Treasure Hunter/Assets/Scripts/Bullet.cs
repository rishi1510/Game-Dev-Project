using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float damage;

    public GameObject popup;

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.name != "Player") {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect, (float)0.333);
        }

        if(collision.collider.GetComponent<ReceiveDamage>() != null) {
            collision.collider.GetComponent<ReceiveDamage>().dealDamage(damage);

            popup.GetComponent<DamagePopup>().Create(transform.position, damage, 1);
        }
    }
}
