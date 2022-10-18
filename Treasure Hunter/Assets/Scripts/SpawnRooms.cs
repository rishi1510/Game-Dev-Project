using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnRooms : MonoBehaviour
{

    public GameObject square;
    public int[,] grid = new int[15,15];
    public int numRooms;
    public GameObject Player;

    void Start()
    {
        createLayout();
        //Player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject);
    }

    private bool searchList(List<int[]> l, int[] a) {
        for(int i=0; i<l.Count; i++) {
            if(l[i][0] == a[0] && l[i][1] == a[1]) {
                return true;
            }
        }
        
        return false;
    }

    private void createLayout() {
        int x, y, rand;
        x = 5;
        y = 5;
        grid[5,5] = 1;

        List<int[]> createdRooms = new List<int[]>();
        List<int[]> possibleRooms = new List<int[]>();

        createdRooms.Add(new int[] {5,5});
        
        for(int n=1; n<numRooms; n++) {
            createdRooms.ForEach(delegate(int[] room) {
                if(searchList(createdRooms, new int[] {x+1, y}) == false && searchList(possibleRooms, new int[] {x+1, y}) == false) {
                    possibleRooms.Add(new int[] {x+1, y});
                }
                if(searchList(createdRooms, new int[] {x-1, y}) == false && searchList(possibleRooms, new int[] {x-1, y}) == false) {
                    possibleRooms.Add(new int[] {x-1, y});
                }
                if(searchList(createdRooms, new int[] {x, y+1}) == false && searchList(possibleRooms, new int[] {x, y+1}) == false) {
                    possibleRooms.Add(new int[] {x, y+1});
                }
                if(searchList(createdRooms, new int[] {x, y-1}) == false && searchList(possibleRooms, new int[] {x, y-1}) == false) {
                    possibleRooms.Add(new int[] {x, y-1});
                }
            });

            rand = Random.Range(0, possibleRooms.Count-1);

            x = possibleRooms[rand][0];
            y = possibleRooms[rand][1];

            createdRooms.Add(new int[] {x, y});
            possibleRooms.RemoveAt(rand);

            grid[x, y] = 1;

            possibleRooms.RemoveAt(0);
        }

        for(int i=0; i<15; i++) {
            for(int j=0; j<15; j++) {
                if(grid[i, j] == 1) {
                    Vector3 position = new Vector3((i-5) * 20, (j-5) * 20, 0);
                    Instantiate(square, position, Quaternion.identity);
                }
            }
        }

        Vector3 playerPos = new Vector3(0, 0, 0);

        //Instantiate(Player, playerPos, Quaternion.identity);
    }
}
