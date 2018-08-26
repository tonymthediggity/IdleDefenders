using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseHealthManager : MonoBehaviour {

    public float baseHealthStat;
    public float baseMaxHealth;
    public GameObject baseObject;

    public Image healthBarFill;
    public GameObject gameOverPanel;

    public float money;
    public GameObject collectorObjParent;
    public int collectorMoney;


    public Text moneyText;
    public Text healthTextAbove50;
    public Text healthTextBelow50;

    public bool isPaused;
    public GameObject pausePanel;

    public bool hasCollector;

    public GameObject turretPrefab;
    public float turretCost;

    public GameObject shopPanel;
    public Text turretButtonText;
    public Text shopErrorText;
    public bool canPlaceTurret = false;

   

	// Use this for initialization
	void Start () {

        

        baseObject = GameObject.FindGameObjectWithTag("Base");
        gameOverPanel.SetActive(false);

        baseHealthStat = baseMaxHealth;

        moneyText.text = money.ToString();

        isPaused = false;

        pausePanel.SetActive(false);

        collectorObjParent = GameObject.FindGameObjectWithTag("CollectorParent");

       // collectorMoney = collectorObjParent.GetComponentInChildren<Collector>().moneyCollected;

        if(collectorObjParent == null)
        {

        }
        else
        {
            collectorMoney = collectorObjParent.GetComponentInChildren<Collector>().moneyCollected;
        }




}
	
	// Update is called once per frame
	void Update () {

        moneyText.text = money.ToString();

        turretButtonText.text = "Buy Turret (" + turretCost.ToString() + ")";

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);

        if (Input.GetMouseButtonDown(1) && canPlaceTurret == true)
        {
            Vector3 wordPos;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                wordPos = hit.point;
            }
            else
            {
                wordPos = Camera.main.ScreenToWorldPoint(mousePos);
            }



            GameObject turretClone;
            turretClone = Instantiate(turretPrefab, wordPos, Quaternion.identity) as GameObject; 
             
            canPlaceTurret = false;
        }





        if (GameObject.FindGameObjectWithTag("Collector"))
        {
            hasCollector = true;
        }
        else
        {
            hasCollector = false;
        }

       

            
        

        if (baseHealthStat > 50)
        {
            healthTextAbove50.enabled = true;
            healthTextBelow50.enabled = false;
            healthTextAbove50.text = baseHealthStat.ToString() + " / " + baseMaxHealth.ToString();
        }

        if(baseHealthStat <= 50)
        {
            healthTextAbove50.enabled = false;
            healthTextBelow50.enabled = true;
            healthTextBelow50.text = baseHealthStat.ToString() + " / " + baseMaxHealth.ToString();
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000))

                Debug.Log("Hit" + hit.collider.gameObject.name);
            {
                if (hit.collider.CompareTag("Money"))
                {
                   
                    money += Random.Range(1, 25);

                    Destroy(hit.collider.gameObject);
                }
            }
        }



        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000))

                
            {
                if (hit.collider.CompareTag("BaseModule"))
                {
                    money += collectorMoney;
                    collectorObjParent.GetComponentInChildren<Collector>().moneyCollected = 0;

                   
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!isPaused)
            {
                
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                

                isPaused = true;
            }
            else
            {
                pausePanel.SetActive(false);
                Time.timeScale = 1;
                isPaused = false;
            }


        }

        collectorObjParent = GameObject.FindGameObjectWithTag("CollectorParent");

       // collectorMoney = collectorObjParent.GetComponentInChildren<Collector>().moneyCollected;

       if(collectorObjParent.GetComponentInChildren<Collector>() != null)
        {
            collectorMoney = collectorObjParent.GetComponentInChildren<Collector>().moneyCollected;
        }
        else
        {
            
        }

        





    }

    private void LateUpdate()
    {

        healthBarFill.fillAmount = baseHealthStat / 100;

        if(baseHealthStat <= 0)
        {
            gameOverPanel.SetActive(true);
        }
        
    }

    public void TakeDamage()
    {
        Debug.Log("");
    }

   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResumeGame()
    {
        shopErrorText.text = null;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void BuyTurret()
    {

        if (money >= turretCost)
        {
            canPlaceTurret = true;
            money -= turretCost;
            turretCost = turretCost * 1.5f;
        }

        if (money < turretCost)
        {
            float timeToDisplayError = 2;
            timeToDisplayError -= Time.deltaTime;

           
                
                shopErrorText.text = "Insufficient Funds";

        }
        
        
    }

    public void BuyCollector()
    {
        money -= 500;

        hasCollector = true;
        collectorObjParent.transform.GetChild(0).gameObject.SetActive(true);
        Debug.Log(collectorObjParent.name + "is now active");
    }

}
