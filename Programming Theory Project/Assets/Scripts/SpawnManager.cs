using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private Vector3 playerpos;
    private int enemyNumber=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = player.transform.position;
        SpawnWave();
    }

    Vector3 GetRandomPos() {
        return new Vector3(GetCoordinate(playerpos.x), playerpos.y + 5, GetCoordinate(playerpos.z));
    }
    float GetCoordinate(float coord) {
        if (Random.Range(0, 2) == 0)
        {
            return Random.Range(coord - 60, coord - 15);
        }
        else {
            return Random.Range(coord + 60, coord + 15);
        }
    }
    void SpawnEnemy() { 
    Instantiate(enemy, GetRandomPos(), enemy.transform.rotation);
    }
    void SpawnWave() {
        if (CountEnemies() < 10) {
            SpawnEnemy();
        }
    }

    int CountEnemies() {
        return FindObjectsOfType<Enemy>().Length;
    }
}
