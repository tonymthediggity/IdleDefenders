using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHP : MonoBehaviour {

    public float baseHP;
    public GameObject enemy;
    public EnemyAI enemyDamage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyDamage = enemy.GetComponent<EnemyAI>();


		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Doing Damage");
            baseHP -= enemyDamage.damage;
        }
    }

  
}
