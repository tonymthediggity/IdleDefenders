using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

   

    public Rigidbody myBody;
    public Vector3 basePos;
    public GameObject playerBase;

    public GameObject spawnedEnemyArray;


    public float enemyHealth;

    

    public float damage;

    public float speed;

	// Use this for initialization
	void Start () {

        myBody = GetComponent<Rigidbody>();
        playerBase = GameObject.FindGameObjectWithTag("Base");
        basePos = playerBase.transform.position;
      

        


		
	}

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(basePos);
        myBody.AddForce(transform.forward * speed);

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
                    
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Base"))
        {
            Destroy(GameObject.Find("Enemy(Clone)"));
        }
    }
}
