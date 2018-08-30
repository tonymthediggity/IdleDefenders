using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

    public GameObject[] enemy;

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {

        enemy = GameObject.FindGameObjectsWithTag("Enemy");

    }

    private void OnMouseDown()
    {
        if (enemy.Length > 0)
        {
            foreach (GameObject go in enemy)
            {
                Destroy(go);
                Destroy(gameObject);
            }
        }
    }
}
