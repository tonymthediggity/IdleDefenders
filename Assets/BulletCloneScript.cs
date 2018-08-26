using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCloneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (!other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 10);
        }
    }
}
