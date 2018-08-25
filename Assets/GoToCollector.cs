using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCollector : MonoBehaviour {

    public Transform collectorPos;
    public Rigidbody myBody;
    public float speed;

    public CapsuleCollider myCollider;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {



        myBody = GetComponent<Rigidbody>();

        myCollider = GetComponent<CapsuleCollider>();
        myCollider.isTrigger = false;



       
        collectorPos = GameObject.FindGameObjectWithTag("Collector").transform;
        myBody.AddForce(transform.forward * speed);

    }

    // Update is called once per frame
    void Update () {
        if (collectorPos != null)
       {
            myBody.transform.LookAt(collectorPos);

            myCollider.isTrigger = true;

            myBody.AddForce(collectorPos.transform.position * speed);
            


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
