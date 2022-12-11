using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHands : MonoBehaviour
{
    public float maxHeight, moveDir = 1, minHeight, moveSpeed;
    public List<Item> heldItems = new List<Item>();

    void Start() {
        Item item = heldItems[Random.Range(0, heldItems.Count)];

        gameObject.GetComponent<SpriteRenderer>().sprite = item.itemSprite;
        gameObject.GetComponent<SpriteRenderer>().flipX = item.flipX;
    }

    void FixedUpdate()
    {
        transform.localPosition += new Vector3(0, moveDir * moveSpeed, 0);

        if(transform.localPosition.y >= maxHeight || transform.localPosition.y <= minHeight) {
            moveDir *= -1;
        }
    }
}

[System.Serializable]
public class Item {
    public Sprite itemSprite;
    public bool flipX;
}
