using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnRooms : MonoBehaviour
{

    public List<GameObject> roomTemplates;
    public GameObject bossRoom;
    public int[,] grid;
    public int gridR, gridC;
    public int numRooms;
    public int endRooms;

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

    private float euclideanDistance(float x1, float y1, float x2, float y2) {
        return (x2 - x1)*(x2 - x1) + (y2 - y1)*(y2 - y1);
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
        float dist = 0;
        int bossRoomX = 0, bossRoomY = 0;
        List<int[]> endRoomsList = new List<int[]>();

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

                        endRoomsList.Add(new int[] {i, j});

                        if(dist < euclideanDistance(i, j, gridR/2, gridC/2)) {
                            dist = euclideanDistance(i, j, gridR/2, gridC/2);

                            bossRoomX = i;
                            bossRoomY = j;
                        }
                    }
                }
                numSurrounding = 0;
            }
        }

        if(numEndrooms < endRooms) {
            createLayout();
            return;
        }

        int keyRoomX = endRoomsList[0][0],keyRoomY = endRoomsList[0][1];

/*        for(int i=0; i<endRoomsList.Count; i++) {
            if(endRoomsList[i][0] != bossRoomX && endRoomsList[i][0] != bossRoomY) {
                keyRoomX = endRoomsList[i][0];
                keyRoomY = endRoomsList[i][1];
                break;
            }
        }*/

        dist = euclideanDistance(bossRoomX, bossRoomY, keyRoomX, keyRoomY);

        for(int i=1; i<endRoomsList.Count; i++) {
            if(dist < euclideanDistance(bossRoomX, bossRoomY, endRoomsList[i][0], endRoomsList[i][1])) {
                keyRoomX = endRoomsList[i][0];
                keyRoomY = endRoomsList[i][1];

                dist = euclideanDistance(bossRoomX, bossRoomY, keyRoomX, keyRoomY);
            }
        }

        grid[keyRoomX, keyRoomY] = 3;
        grid[bossRoomX, bossRoomY] = 2;

        if(numEndrooms < endRooms || (keyRoomX == gridR/2 && keyRoomY == gridC/2)) {
            createLayout();
            return;
        }
        else {
            Debug.Log("End rooms - " + numEndrooms);
            for(int i=0; i<gridR; i++) {
                for(int j=0; j<gridC; j++) {
                    if(grid[i, j] == 1 || grid[i, j] == 3) {
                        Vector3 position = new Vector3((i-(gridR/2)) * 20, (j-(gridC/2)) * 20, 0);
                        int randTemplateID = Random.Range(0, roomTemplates.Count);

                        GameObject room = Instantiate(roomTemplates[randTemplateID], position, Quaternion.identity);
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

                        if(grid[i, j] == 3) {
                            room.GetComponent<RoomData>().keyRoom = true;
                            Debug.Log("Key room - " + i + ", " + j);
                        }
                    }
                    else if(grid[i, j] == 2) {
                        Vector3 position = new Vector3((i-(gridR/2)) * 20, (j-(gridC/2)) * 20, 0);

                        GameObject room = Instantiate(bossRoom, position, Quaternion.identity);

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

                        Debug.Log("Boss room - " + i + ", " + j);
                    }

                }
            }
        }
    }
}
