using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCollector : MonoBehaviour {

    public Transform collectorPos;
    public Rigidbody myBody;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {
        collectorPos = GameObject.FindGameObjectWithTag("Collector").transform;
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        if (collectorPos != null)
        {
            myBody.transform.LookAt(collectorPos);
            myBody.AddForce(transform.forward * speed);
        }


	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            Destroy(gameObject);
        }
    }
}
