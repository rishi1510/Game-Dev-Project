using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public List<Loot> items = new List<Loot>();
    public List<Loot> possibleDrops = new List<Loot>();

    private List<Loot> getLoot() {
        int rand = Random.Range(1, 101);

        possibleDrops = new List<Loot>();
        foreach(Loot item in items) {
            if(rand <= item.dropChance) {
                possibleDrops.Add(item);
            }
        }

        if(possibleDrops.Count > 0) {
            //Loot drop = possibleDrops[Random.Range(0, possibleDrops.Count)];
            //return drop;

            return possibleDrops;
        }

        

        Debug.Log(possibleDrops.Count);
        return null;
    }

    public void instantiateLoot(Vector3 pos) {
        List<Loot> drops = getLoot();
        /*if(drop != null) {
            Instantiate(drop.item, pos, Quaternion.identity);
        }*/

        if(drops == null) {
            return;
        }

        foreach(Loot drop in drops) {
            GameObject item = Instantiate(drop.item, transform.position, Quaternion.identity);
            item.transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), 0), 0.5f);
        }
    }
}

[System.Serializable]
public class Loot {
    public GameObject item;
    public int dropChance;
}
