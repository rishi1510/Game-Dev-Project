using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public int xCoord;
    public int yCoord;
    public bool left = false, right = false, top = false, bottom = false;
    
    public Transform spawnpoint;

    public GameObject LWall, RWall, TWall, BWall;

    void Start() {
        SpawnWalls();
    }

    private void SpawnWalls() {
        if(left) {
            Instantiate(LWall, spawnpoint.position, spawnpoint.rotation);
        }
        if(right) {
            Instantiate(RWall, spawnpoint.position, spawnpoint.rotation);
        }
        if(top) {
            Instantiate(TWall, spawnpoint.position, spawnpoint.rotation);
        }
        if(bottom) {
            Instantiate(BWall, spawnpoint.position, spawnpoint.rotation);
        }
    }
}
