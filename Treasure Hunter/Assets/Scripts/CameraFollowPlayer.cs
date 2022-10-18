using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 offset;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if(player != null) {
            Vector3 newPos = Vector3.Lerp(transform.position, player.position + offset, smoothing);
            transform.position = newPos;
        }
        
    }
}
