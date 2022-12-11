using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public int xCoord;
    public int yCoord;
    public bool left = false, right = false, top = false, bottom = false;
    public bool bossRoom, keyRoom;
    
    public Transform spawnpoint;

    public List<GameObject> gates = new List<GameObject>();

    public GameObject LWall, RWall, TWall, BWall, LGate, RGate, BGate, TGate, key;

    void Start() {
        SpawnWalls();

        if(bossRoom) {
            SpawnGates();
        }

        if(keyRoom) {
            Instantiate(key, spawnpoint.position, spawnpoint.rotation);
        }
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

    public void SpawnGates() {
        if(!left) {
            GameObject leftGate = Instantiate(LGate, spawnpoint.position, spawnpoint.rotation);
            gates.Add(leftGate);
        }
        if(!right) {
            GameObject rightGate = Instantiate(RGate, spawnpoint.position, spawnpoint.rotation);
            gates.Add(rightGate);
        }
        if(!top) {
            GameObject topGate = Instantiate(TGate, spawnpoint.position, spawnpoint.rotation);
            gates.Add(topGate);
        }
        if(!bottom) {
            GameObject bottomGate = Instantiate(BGate, spawnpoint.position, spawnpoint.rotation);
            gates.Add(bottomGate);
        }
    }
}
