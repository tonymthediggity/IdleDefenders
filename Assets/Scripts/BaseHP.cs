using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHP : MonoBehaviour {

    public GameObject baseManager;
    public BaseHealthManager baseHealthScript;
    public float baseHealthStatItself;

   

    

    public float clickDamage = 10;

	// Use this for initialization
	void Start () {

        baseManager = GameObject.FindGameObjectWithTag("BaseHealthManager");
        baseHealthScript = baseManager.GetComponent<BaseHealthManager>();
        baseHealthStatItself = baseHealthScript.baseHealthStat;
        
        
		
	}
	
	// Update is called once per frame
	void Update () {
        

        








    }

    

    public void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Enemy"))
        {
            baseHealthScript.baseHealthStat -= other.GetComponent<EnemyAI>().damage;
        }

    }

    /* private void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Enemy");
         {
             Debug.Log("Enemy Dying");
             baseHP = baseHP - 10;
         }
     }*/



}




  

