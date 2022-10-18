using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement, mousePos;

    void Update() {
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.deltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
