using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHP : MonoBehaviour {

    public float baseHP;
    public GameObject enemy;
    public EnemyAI enemyDamage;
    public float enemyHealth;

    public float clickDamage = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyDamage = enemy.GetComponent<EnemyAI>();

        

        


    }

    void HurtEnemy()
    {
        enemyHealth -= clickDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().CompareTag("Enemy"))
        {
            baseHP -= enemyDamage.damage;
        }
    }



}




  

