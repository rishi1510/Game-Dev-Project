using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnRooms : MonoBehaviour
{

    public GameObject square;
    public int[,] grid;
    public int gridR, gridC;
    public int numRooms;
    public int endRooms;
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
        grid = new int[100, 100];
        int x, y, rand;
        x = gridR/2;
        y = gridC/2;
        grid[x, y] = 1;

        List<int[]> createdRooms = new List<int[]>();
        List<int[]> possibleRooms = new List<int[]>();

        createdRooms.Add(new int[] {gridR/2, gridC/2});
        
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
        }

        int numSurrounding = 0;
        int numEndrooms = 0;
        for(int i=0; i<15; i++) {
            for(int j=0; j<15; j++) {
                if(grid[i,j] == 1) {
                    if(grid[i-1,j] == 1) {
                        numSurrounding++;
                    } 
                    if(grid[i+1,j] == 1) {
                        numSurrounding++;
                    } 
                    if(grid[i,j-1] == 1) {
                        numSurrounding++;
                    } 
                    if(grid[i,j+1] == 1) {
                        numSurrounding++;
                    } 

                    if(numSurrounding == 1) {
                        numEndrooms++;
                    }
                }
                numSurrounding = 0;
            }
        }

        if(numEndrooms < endRooms) {
            createLayout();
        }
        else {
            for(int i=0; i<gridR; i++) {
                for(int j=0; j<gridC; j++) {
                    if(grid[i, j] == 1) {
                        Vector3 position = new Vector3((i-(gridR/2)) * 19, (j-(gridC/2)) * 19, 0);
                        GameObject room = Instantiate(square, position, Quaternion.identity);
                        room.GetComponent<RoomData>().xCoord = i;
                        room.GetComponent<RoomData>().yCoord = j;

                        if(grid[i-1,j] == 0) {
                            room.GetComponent<RoomData>().left = true;
                        }

                        if(grid[i+1, j] == 0) {
                            room.GetComponent<RoomData>().right = true;
                        }

                        if(grid[i, j+1] == 0) {
                            room.GetComponent<RoomData>().top = true;
                        }

                        if(grid[i, j-1] == 0) {
                            room.GetComponent<RoomData>().bottom = true;
                        }
                    }
                }
            }
        }
    }
}
