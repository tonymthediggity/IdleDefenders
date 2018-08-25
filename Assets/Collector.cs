using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour {

    public int moneyCollected;

    public float moneyToGive = 0;

	// Use this for initialization
	void Start () {

        moneyCollected = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            
            moneyCollected = Random.Range(1, 25) + moneyCollected;
            
        }
    }
}
