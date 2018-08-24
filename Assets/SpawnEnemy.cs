using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public int index;

    public GameObject[] enemyPrefabs;

    public GameObject enemyClone;

    public GameObject[] spawnedEnemies;

    public float timeTilSpawn;

    public GameObject currentEnemyToSpawn;

    public bool canSpawn = true;

    

	// Use this for initialization
	void Start () {

        index = Random.Range(0, enemyPrefabs.Length);

        currentEnemyToSpawn = enemyPrefabs[index];

        print(currentEnemyToSpawn.name);

        
		
	}
	
	// Update is called once per frame
	void Update () {

        timeTilSpawn = timeTilSpawn - Time.deltaTime;

        

        if(timeTilSpawn <= 0)
        {
            Spawn();
            ResetSpawnTimer();
            
        }

        spawnedEnemies = GameObject.FindGameObjectsWithTag("Enemy");




    }

    void ResetSpawnTimer()
    {
        timeTilSpawn = Random.Range(5, 10);
    }

    void Spawn()
    {
        
       enemyClone = Instantiate(enemyPrefabs[index], transform.position, transform.rotation);
    }
}
