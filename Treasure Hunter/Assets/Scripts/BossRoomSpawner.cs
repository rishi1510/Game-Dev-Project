using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSpawner : MonoBehaviour
{
    
    public Transform player, bossSpawn;
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    public ColliderTrigger colliderTrigger;

    public int curWave;
    public int waveVal;

    public List<Transform> SpawnLocations = new List<Transform>();
    public int numWaves;
    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    private Vector3 offset;
    public GameObject chest, boss;

    private enum State {
        Idle, 
        Active,
        Finished
    }

    private State state;

    private void Awake() {
        state = State.Idle;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
        curWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Active && waveTimer >= 0 && curWave < numWaves) {
            waveTimer -= Time.deltaTime;
            if(waveTimer <= 0 || battleOver()) {
                GenerateWave();
                curWave ++;
            }
        }

        if(state != State.Finished && battleOver() && curWave >= numWaves) {
            state = State.Finished;
            removeGates();
            PlayerStats.playerStats.clearedRooms++;

            PlayerStats.playerStats.updateRoomCount();

            if(GetComponent<RoomData>().keyRoom == false) {
                Instantiate(chest, GetComponent<RoomData>().spawnpoint.transform.position, GetComponent<RoomData>().spawnpoint.rotation);
            }

            PlayerStats.playerStats.inBattle = false;
        }
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e) {
        if(state == State.Idle) {
            spawnGates();
            state = State.Active;
            colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
            GenerateWave();
            curWave = 1;

            GameObject Boss = Instantiate(boss, bossSpawn.position, bossSpawn.rotation);
            spawnedEnemies.Add(Boss);


            PlayerStats.playerStats.inBattle = true;
        }   
    }

    private void spawnGates() {
        transform.GetComponent<RoomData>().SpawnGates();
    }

    private void removeGates() {
        List<GameObject> gates = transform.GetComponent<RoomData>().gates;

        for(int i=0; i<gates.Count; i++) {
            Destroy(gates[i]);
        }
    }

    private bool battleOver() {
        foreach(GameObject enemy in spawnedEnemies) {
            if(enemy) {
                return false;
            }
        }
        return true;
    }

    public void GenerateWave() {
        waveVal = 5 + curWave;
        GenerateEnemies();

        spawnInterval = 0;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies() {
        List<GameObject> generatedEnemies = new List<GameObject>();
        int numEnemies = 0;

        while(waveVal > 0 && numEnemies <= 5) {
            int randEnemyID = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyID].cost;

            if(waveVal - randEnemyCost >= 0) {
                generatedEnemies.Add(enemies[randEnemyID].enemyPrefab);
                waveVal -= randEnemyCost;
                numEnemies++;
            }
            else if(waveVal <= 0) {
                break;
            }
        }

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;

        List<Transform> possibleSpawns = SpawnLocations;
        foreach(GameObject enemy in enemiesToSpawn) {
            if(possibleSpawns.Count > 0) {
                int spawnID = Random.Range(0, possibleSpawns.Count);
                spawnedEnemies.Add(Instantiate(enemy, possibleSpawns[spawnID].position, possibleSpawns[spawnID].rotation));

                possibleSpawns.RemoveAt(spawnID);
            }
        }
        enemiesToSpawn.Clear();
    }
}
