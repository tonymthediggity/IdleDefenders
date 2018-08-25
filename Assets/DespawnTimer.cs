using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour {

    public float moneyDespawnTimer = 5f;

    // Use this for initialization
    void Start () {
		
	}

    

    // Update is called once per frame
    void Update () {

        moneyDespawnTimer -= Time.deltaTime;
        if (moneyDespawnTimer <= 0)
        {
            Destroy(gameObject);
        }
		
	}
}
