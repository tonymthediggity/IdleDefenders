using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

   

    public Rigidbody myBody;
    public GameObject myBodyGraphics;
    public Collider sphereCollider;
    public GameObject afterBurner;

    public EnemyAI mainScript;

    public Vector3 basePos;
    public GameObject playerBase;

    public float baseCurrentHp;

    public BaseHealthManager pauseChecker;

    public ParticleSystem explosionThing;

    



    public GameObject spawnedEnemyArray;


    public float enemyHealth;



    public float damage;

    public float speed;

    public GameObject moneyPrefab;
    public GameObject healthPickupPrefab;

    public int dropChance;








    // Use this for initialization
    void Start () {

        myBody = GetComponent<Rigidbody>();
        damage = Random.Range(1, 20);

        explosionThing = GameObject.FindObjectOfType<ParticleSystem>();
        sphereCollider = GetComponent<Collider>();
        mainScript = GetComponent<EnemyAI>();

        
      
       

        
      

        


		
	}

    private void Awake()
    {
        pauseChecker = GameObject.FindGameObjectWithTag("BaseHealthManager").GetComponent<BaseHealthManager>();
        speed = (Random.Range(0.33f, 1.2f) * pauseChecker.waveNumber) * .44f;

        dropChance = Random.Range(1, 10);
        
       
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

    



      /*  if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000))

                Debug.Log("Hit" + hit.collider.gameObject.name);
            {
                if (hit.collider.gameObject.tag == "Enemy") ;
                {

                    enemyHealth -= pauseChecker.clickDamage;


                    if (GetComponent<EnemyAI>().enemyHealth <= 0)
                    {

                        GameObject moneyClone;
                        moneyClone = Instantiate(moneyPrefab, transform.position, transform.rotation) as GameObject;
                        moneyClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);




                        Destroy(gameObject);




                    }
                }
        }

        
        }*/



    }

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {

           
            Destroy(gameObject, 0.02f);
        }

        
    }

    private void OnMouseDown()
    {



        enemyHealth -= pauseChecker.clickDamage;


        if (GetComponent<EnemyAI>().enemyHealth <= 0)
        {
            if (dropChance >=2)
            {
                mainScript.enabled = false;
                GameObject moneyClone;
                moneyClone = Instantiate(moneyPrefab, transform.position, transform.rotation) as GameObject;
                moneyClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                myBodyGraphics.SetActive(false);
                sphereCollider.enabled = false;
                afterBurner.SetActive(false);
                explosionThing.Play();


                Destroy(gameObject, 2);
            }

            if(dropChance <= 1)
            {

                mainScript.enabled = false;
                GameObject healthPickupClone;
                healthPickupClone = Instantiate(healthPickupPrefab, transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
                healthPickupClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

                myBodyGraphics.SetActive(false);
                sphereCollider.enabled = false;
                afterBurner.SetActive(false);
                explosionThing.Play();
                Destroy(gameObject, 2);
            }
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameObject moneyClone;
            moneyClone = Instantiate(moneyPrefab, transform.position, transform.rotation) as GameObject;
            moneyClone.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            Destroy(gameObject);




        }
    }
}
