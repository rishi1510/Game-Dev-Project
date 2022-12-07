using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHands : MonoBehaviour
{
    public float maxHeight, moveDir = 1, minHeight, moveSpeed;

    public List<Sprite> heldItems = new List<Sprite>();

    void Start() {
        Sprite item = heldItems[Random.Range(0, heldItems.Count)];

        gameObject.GetComponent<SpriteRenderer>().sprite = item;
    }

    void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, moveDir * moveSpeed, 0);

        if(transform.localPosition.y >= maxHeight || transform.localPosition.y <= minHeight) {
            moveDir *= -1;
        }
    }
}
