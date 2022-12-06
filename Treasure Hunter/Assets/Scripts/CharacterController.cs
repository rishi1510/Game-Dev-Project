using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement, mousePos;
    public GameObject crosshairPrefab, crosshair;
    private float activeMoveSpeed;
    public float dashSpeed, dashLength = 0.5f, dashCooldown = 1f;
    private float dashCount, dashCoolCounter;
    public bool isDashing;
    public TrailRenderer trailRenderer;
    public Animator animator;



    void Start() {
        activeMoveSpeed = moveSpeed;
        isDashing = false;
        crosshair = Instantiate(crosshairPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }

    void Update() {
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.Space)) {
            if(dashCoolCounter <= 0 && dashCount <= 0) {
                activeMoveSpeed = dashSpeed;
                dashCount = dashLength;
                trailRenderer.emitting = true;
                isDashing = true;
            }
        }

        if(dashCount > 0) {
            dashCount -= Time.deltaTime;

            if(dashCount <= 0) {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
                trailRenderer.emitting = false;
                isDashing = false;
            }
        }

        if(dashCoolCounter > 0) {
            dashCoolCounter -= Time.deltaTime;
        }

        if(movement.x != 0 || movement.y != 0) {
            animator.SetBool("IsWalking", true);
        }
        else {
            animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement.normalized * activeMoveSpeed * Time.fixedDeltaTime);

        crosshair.transform.position = mousePos;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        if(angle <=90 && angle >= -90) {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
