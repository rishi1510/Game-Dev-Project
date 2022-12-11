using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPickup : MonoBehaviour
{
    public float hp;
    public int type;
    public GameObject popup;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.name == "Player") {
            switch(type) {
                case 1:
                    hp = Random.Range(5, 11);
                    PlayerStats.playerStats.healCharacter(hp);
                    popup.GetComponent<DamagePopup>().Create(transform.position, hp, 3);
                    Destroy(gameObject);
                    break;

                case 2:
                    PlayerStats.playerStats.increaseMaxHealth(25);
                    popup.GetComponent<DamagePopup>().Create(transform.position, "Max Health +25");
                    Destroy(gameObject);
                    break;

                case 3:
                    PlayerStats.playerStats.setdamageMultiplier(0.1f);
                    popup.GetComponent<DamagePopup>().Create(transform.position, "Damage +10%");
                    Destroy(gameObject);
                    break;

                case 4:
                    PlayerStats.playerStats.pickupKey();
                    Destroy(gameObject);
                    break;

                case 5:
                    PlayerStats.playerStats.gameOver();
                    break;

            }
        /*    hp = Random.Range(5, 11);

            PlayerStats.playerStats.healCharacter(hp);

            popup.GetComponent<DamagePopup>().Create(transform.position, hp, 3);
            Destroy(gameObject); */
        }
    }
}
