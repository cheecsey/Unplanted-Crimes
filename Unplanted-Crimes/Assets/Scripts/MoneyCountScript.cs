using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MoneyCountScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyCounterText; // text box to display amount of money player has
    private int moneyCounter;

    // seeds
    public Sprite[] moneySprites; // sprite array for each seed packet

    private bool canCollect = false;
    private GameObject seedInRange;

    void Start()
    {
        moneyCounter = 0; // auto set money to 0 at start of game

        UpdateMoneyCountUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // press 'q' to sell all your money
        {
            moneyCounter = 0; // sets the players money back to 0
            UpdateMoneyCountUI();
        }
        if (canCollect && Input.GetKeyDown(KeyCode.E) && seedInRange != null)
        {
            AddMoney(); // add 10 to money count
            Destroy(seedInRange); // removes the seed packet
            canCollect = false;
            seedInRange = null;
        }
    }

    private void UpdateMoneyCountUI()
    {
        moneyCounterText.text = moneyCounter.ToString(); // int to string

        if (moneyCounter >= 500)
        {
            SceneManager.LoadScene("EndGame"); // game over
        }
    }

    private void AddMoney()
    {
        moneyCounter = moneyCounter + 10; // adds 10 to money for every seed (500 to win)
        UpdateMoneyCountUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Seed")) // only interract with seeds
        {
            canCollect = true;
            seedInRange = collision.gameObject;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("EndGame");
    }

}
