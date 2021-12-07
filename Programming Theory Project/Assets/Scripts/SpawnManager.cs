using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    private Vector3 playerpos;
    private int enemyNumber=7;
    private int waveNumber = 0;
    private bool isNewWave = false;
    public Text waveText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        playerpos = player.transform.position;
        if (CountEnemies() == 0)
        {
            waveNumber++;
            waveText.text = "Wave " + waveNumber;
            enemyNumber += 3;
            isNewWave = true;
        }
        if (isNewWave) {
            SpawnWave();
        }
        if (CountEnemies() >= enemyNumber)
        {
            isNewWave = false;
        }
        
       
       
    }

    Vector3 GetRandomPos() {
        return new Vector3(GetCoordinate(playerpos.x), 60, GetCoordinate(playerpos.z));
    }
    float GetCoordinate(float coord) {
        if (coord < 90) { 
            coord = 90;
        }
        if (coord > 410) {
            coord = 410;
        }
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
        if (CountEnemies() < enemyNumber) {
            SpawnEnemy();
        }
    }

    int CountEnemies() {
        return FindObjectsOfType<Enemy>().Length;
    }
}
