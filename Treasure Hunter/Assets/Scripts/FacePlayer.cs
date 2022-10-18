using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate() {
        if(player != null) {
            Vector2 lookDir = player.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}
