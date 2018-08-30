using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour {

    public float healthToGive;
    public BaseHealthManager baseScript;
    public static Text healthErrorText;

    public float errorTimer = 0.4f;

	// Use this for initialization
	void Start () {
        baseScript = GameObject.FindGameObjectWithTag("BaseHealthManager").GetComponent<BaseHealthManager>();
        healthToGive = Random.Range(5, 20);

        healthErrorText = GetComponentInChildren<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {

        
        
        

        if (baseScript.baseHealthStat < baseScript.baseMaxHealth)
        {

            baseScript.baseHealthStat += healthToGive;
            Destroy(gameObject);
        }

        
    }
}
