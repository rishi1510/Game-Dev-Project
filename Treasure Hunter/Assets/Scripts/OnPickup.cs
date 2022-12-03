using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPickup : MonoBehaviour
{
    public float hp;
    public GameObject popup;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.name == "Player") {
            hp = Random.Range(5, 11);

            PlayerStats.playerStats.healCharacter(hp);

            popup.GetComponent<DamagePopup>().Create(transform.position, hp, 3);
            Destroy(gameObject);
        }
    }
}
