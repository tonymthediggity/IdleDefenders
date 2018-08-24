using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public int index;

    public GameObject[] enemyPrefabs;

    public float timeTilSpawn;

    public GameObject currentEnemyToSpawn;

	// Use this for initialization
	void Start () {

        index = Random.Range(0, enemyPrefabs.Length);

        currentEnemyToSpawn = enemyPrefabs[index];

        print(currentEnemyToSpawn.name);

        
		
	}
	
	// Update is called once per frame
	void Update () {

        

		
	}
}
