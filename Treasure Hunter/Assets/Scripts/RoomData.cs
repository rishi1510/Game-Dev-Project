using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    public int xCoord;
    public int yCoord;
    public bool left = false, right = false, top = false, bottom = false;
    
    public Transform L, R, T, B;

    public GameObject hWall, vWall;

    void Start() {
        SpawnWalls();
    }

    private void SpawnWalls() {
        if(left) {
            Instantiate(vWall, L.position, L.rotation);
        }
        if(right) {
            Instantiate(vWall, R.position, R.rotation);
        }
        if(top) {
            Instantiate(hWall, T.position, T.rotation);
        }
        if(bottom) {
            Instantiate(hWall, B.position, B.rotation);
        }

        //Instantiate(vWall, L.position, L.rotation);
    }
}
