using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPivot : MonoBehaviour
{
    public GameObject enemy, player, heldItem;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate() {
        if(player != null) {
            Vector3 lookDir = player.transform.position - transform.position;
            lookDir.Normalize();

            float rotationZ = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

            if(rotationZ < -90 || rotationZ > 90) {
                enemy.GetComponent<SpriteRenderer>().flipX = true;

                if(enemy.transform.eulerAngles.y == 0) {
                    transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
                }
                else if(enemy.transform.eulerAngles.y == 180) {
                    transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
                }

                if(heldItem.transform.localPosition.x < 0) {
                    Vector3 temp = heldItem.transform.localPosition;
                    temp.x *= -1;
                    heldItem.transform.localPosition = temp;

                    heldItem.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            else {
                enemy.GetComponent<SpriteRenderer>().flipX = false;

                if(heldItem.transform.localPosition.x > 0) {
                    Vector3 temp = heldItem.transform.localPosition;
                    temp.x *= -1;
                    heldItem.transform.localPosition = temp;

                    heldItem.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
    }
}
