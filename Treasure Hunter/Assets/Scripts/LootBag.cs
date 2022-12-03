using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public List<Loot> items = new List<Loot>();
    public List<Loot> possibleDrops = new List<Loot>();

    private Loot getLoot() {
        int rand = Random.Range(1, 101);

        possibleDrops.Clear();
        foreach(Loot item in items) {
            if(rand <= item.dropChance) {
                possibleDrops.Add(item);
            }
        }

        if(possibleDrops.Count > 0) {
            Loot drop = possibleDrops[Random.Range(0, possibleDrops.Count)];
            return drop;
        }

        Debug.Log(possibleDrops.Count);
        return null;
    }

    public void instantiateLoot(Vector3 pos) {
        Loot drop = getLoot();
        if(drop != null) {
            Instantiate(drop.item, pos, Quaternion.identity);
        }
    }
}

[System.Serializable]
public class Loot {
    public GameObject item;
    public int dropChance;
}
