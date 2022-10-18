using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;
    public Transform SpawnPoint;

    void Start()
    {
        Instantiate(Enemy, SpawnPoint.position, SpawnPoint.rotation);
    }
}
