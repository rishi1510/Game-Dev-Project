using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Transform player;
    public Transform SpawnPoint;
    public float spawnRate;

    public float numEnemies, numSpawned;
    private int x, y;
    private Vector3 offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        numEnemies = Random.Range(2, numEnemies);

        if(player != null && (Vector3.Distance(player.position, SpawnPoint.position) <= 10)) {
            x = Random.Range(-9, 9);
            y = Random.Range(-9, 9);
            offset.x = x;
            offset.y = y;

            Instantiate(Enemy, SpawnPoint.position + offset, SpawnPoint.rotation);
        }

        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        float delay = Random.Range(0, spawnRate);

        yield return new WaitForSeconds(delay);

        if(player != null && (Vector3.Distance(player.position, SpawnPoint.position) <= 10)) {
            x = Random.Range(-6, 6);
            y = Random.Range(-6, 6);
            offset.x = x;
            offset.y = y;

            Instantiate(Enemy, SpawnPoint.position + offset, SpawnPoint.rotation);

            numSpawned++;
        }

        if(numSpawned <= numEnemies) {
            StartCoroutine(Spawn()); 
        }
        else {
            Debug.Log("Last Enemy!");
        }
    }
}
