using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGate : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        if(PlayerStats.playerStats.hasKey == true && PlayerStats.playerStats.inBattle == false) {
            Destroy(gameObject);
        }
    }
}
