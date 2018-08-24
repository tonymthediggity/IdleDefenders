using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public Rigidbody myBody;
    public Vector3 basePos;
    public GameObject playerBase;

    public float damage;

    public float speed;

	// Use this for initialization
	void Start () {

        myBody = GetComponent<Rigidbody>();
        playerBase = GameObject.FindGameObjectWithTag("Base");
        basePos = playerBase.transform.position;


		
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(basePos);
        myBody.AddForce(transform.forward * speed);
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            Destroy(gameObject);
        }
    }
}
