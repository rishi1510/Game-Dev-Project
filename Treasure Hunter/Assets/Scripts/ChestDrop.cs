using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDrop : MonoBehaviour
{
    public Sprite chestOpen;
    public bool isOpen;

    void Start() {
        isOpen = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(!isOpen) {
            GetComponent<SpriteRenderer>().sprite = chestOpen;

            if(collider.name == "Player") {
                GetComponent<LootBag>().instantiateLoot(transform.position);
            }

            isOpen = true;
        }
    }
}
