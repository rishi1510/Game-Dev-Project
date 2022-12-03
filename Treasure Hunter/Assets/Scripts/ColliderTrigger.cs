using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.name == "Player") {
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        } 
    }
}
