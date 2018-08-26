using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCollector : MonoBehaviour {

    public GameObject collectorParent;
    public Transform collectorPosition;

    public Rigidbody myBody;

    public CapsuleCollider myCollider;

    public float speed;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()
    {

        myBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<CapsuleCollider>();
        collectorParent = GameObject.FindGameObjectWithTag("CollectorParent");
        collectorPosition = collectorParent.GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update () {

        transform.LookAt(collectorPosition);
        myBody.AddForce(transform.forward * speed);


		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collector"))
        {
            Destroy(gameObject);
        }
    }
}
