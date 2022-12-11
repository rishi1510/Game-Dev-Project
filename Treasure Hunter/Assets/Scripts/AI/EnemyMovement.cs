using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f, attackTime = 0.5f;
    public Animator animator;
    public GameObject pivotPoint;
    public bool isAttacking;


    public void moveEnemy(Vector2 direction) {
        rb.MovePosition(rb.position + direction.normalized * moveSpeed * Time.fixedDeltaTime);

        if(direction != Vector2.zero) 
            animator.SetBool("isRunning", true);
    }

    public void attack() {
        Debug.Log("attacking");
        animator.SetBool("isRunning", false);

        
    }

}
