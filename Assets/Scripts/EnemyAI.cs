using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

   

    public Rigidbody myBody;

    public Vector3 basePos;
    public GameObject playerBase;

    public float baseCurrentHp;

    public BaseHealthManager pauseChecker;



    public GameObject spawnedEnemyArray;


    public float enemyHealth;



    public float damage = 10;

    public float speed;

    public GameObject moneyPrefab;


   

    

   

	// Use this for initialization
	void Start () {

        myBody = GetComponent<Rigidbody>();
       

        
      

        


		
	}

    private void Awake()
    {
        pauseChecker = GameObject.FindGameObjectWithTag("BaseHealthManager").GetComponent<BaseHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(basePos);
        myBody.AddForce(transform.forward * speed);

        if(pauseChecker.isPaused == true)
        {
            myBody.Sleep();
        }
        else
        {
            myBody.WakeUp();
        }

    

        spawnedEnemyArray = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnEnemy>().spawnedEnemies[0];

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000))

                Debug.Log("Hit" + hit.collider.gameObject.name);
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    GameObject moneyClone;
                    moneyClone = Instantiate(moneyPrefab, hit.transform.position, hit.transform.rotation) as GameObject;
                    moneyClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                    
                    
                    
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        

    }

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {

           
            Destroy(gameObject, 0.02f);
        }

        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameObject moneyClone;
            moneyClone = Instantiate(moneyPrefab, transform.position, transform.rotation) as GameObject;
            moneyClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
