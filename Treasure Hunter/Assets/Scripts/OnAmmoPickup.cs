using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAmmoPickup : MonoBehaviour
{
    public float ammo;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.name == "Player") {
            ammo = Random.Range(1, 11);

            PlayerStats.playerStats.ammoPickup(ammo);

            Destroy(gameObject);
        }
    }
}
