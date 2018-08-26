using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour {

    public GameObject collectorParent;
    public Collector collectorObj;

	// Use this for initialization
	void Start () {

        
        
		
	}

    public void Awake()
    {
        collectorParent = GameObject.FindGameObjectWithTag("CollectorParent");

        collectorObj = collectorParent.GetComponentInChildren<Collector>();

        if (collectorObj != null)
        {
            GetComponent<MoveToCollector>().enabled = true;
        }
        else
        {
            GetComponent<MoveToCollector>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
