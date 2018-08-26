using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

  public GameObject[] enemies;
    public GameObject turretObj;
    public GameObject closestEnemy;

    public GameObject bulletPrefab;
    public float fireRate;
    public float defaultFireRate;

    public float bulletSpeed;
    public GameObject firePoint;
    public Vector3 firePointPos;

    public float turretSpeed;

    public bool hasShot = false;





    // Use this for initialization
    void Start()
    {



    }

    public void Awake()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        firePointPos = this.transform.GetChild(0).GetChild(0).GetChild(0).transform.position;

        FindNearestEnemy();
        if (closestEnemy != null)
        {
            transform.LookAt(closestEnemy.transform);
        }

        
        //proper vector for rotation for reference        transform.Rotate(Vector3.up);


        //firePointPos = firePoint.transform.position;

        if(closestEnemy != null && fireRate == defaultFireRate)
        {
            Shoot();
        }

        if(fireRate <= 0)
        {
            hasShot = false;
            fireRate = defaultFireRate;
        }

        if(hasShot == true)
        {
            fireRate = fireRate - Time.deltaTime;
        }










    }

    GameObject FindNearestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float minDistance = 0;
        int count = 0;

        foreach (GameObject enemyItem in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemyItem.transform.position);
            if (count == 0)
            {
                minDistance = dist;
                closestEnemy = enemyItem;
                count++;
            }
            else
            {
                if (dist < minDistance)
                {
                    minDistance = dist;
                    closestEnemy = enemyItem;
                }
            }
        }
        return closestEnemy;
    }

    public void Shoot()
    {
        hasShot = true;
        GameObject bulletClone;
        bulletClone = Instantiate(bulletPrefab, firePointPos, Quaternion.identity) as GameObject;
        var myBody = bulletClone.GetComponent<Rigidbody>();
        myBody.AddForce(transform.forward * bulletSpeed);
       // bulletClone.transform.Translate((firePoint.transform.forward - closestEnemy.transform.position) * bulletSpeed * Time.deltaTime);
       // Destroy(bulletClone);
        
    }


}

