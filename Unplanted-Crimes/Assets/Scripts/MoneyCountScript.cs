using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MoneyCountScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyCounterText; // text box to display amount of money player has
    private int moneyCounter;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            moneyCounter = moneyCounter + 10;
            UpdateMoneyCountUI();
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
        moneyCounter = moneyCounter + 10;
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
