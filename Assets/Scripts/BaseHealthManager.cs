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

    public int money;
    public GameObject collectorObj;
    public int collectorMoney;


    public Text moneyText;
    public Text healthTextAbove50;
    public Text healthTextBelow50;

    public bool isPaused;
    public GameObject pausePanel;

   

	// Use this for initialization
	void Start () {

        baseObject = GameObject.FindGameObjectWithTag("Base");
        gameOverPanel.SetActive(false);

        baseHealthStat = baseMaxHealth;

        isPaused = false;

        pausePanel.SetActive(false);

        collectorObj = GameObject.FindGameObjectWithTag("Collector");

        collectorMoney = collectorObj.GetComponent<Collector>().moneyCollected;




}
	
	// Update is called once per frame
	void Update () {

        moneyText.text = money.ToString();

       

            collectorMoney = collectorObj.GetComponent<Collector>().moneyCollected;
        

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

                Debug.Log("Hit" + hit.collider.gameObject.name);
            {
                if (hit.collider.CompareTag("BaseModule"))
                {
                    money += collectorMoney;
                    collectorObj.GetComponent<Collector>().moneyCollected = 0;

                   
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

    }

    public void BuyCollector()
    {

    }

}
