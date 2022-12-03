using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player;
    public float speed, range, timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null && Vector3.Distance(transform.position, player.position) <= range) {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed);
        }
        else {
            timer -= Time.deltaTime;
            if(timer < 0) {
                Destroy(gameObject);
            }
        }
    }
}
