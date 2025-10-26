using UnityEngine;
using UnityEngine.UI;

public class MoneyCountScript : MonoBehaviour
{
    [SerializeField] Text moneyCounterText; // text box to display amount of money player has
    private int moneyCounter;

    void Start()
    {
        moneyCounter = 0; // auto set money to 0 at start of game
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // press 'q' to sell all your money
        {
            moneyCounter = 0; // sets the players money back to 0
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            moneyCounter = moneyCounter + 10;
        }
    }

    private void UpdateMoneyCountUI()
    {
        moneyCounterText.text = moneyCounter.ToString(); // int to string
    }

    private void AddMoney()
    {
        moneyCounter = moneyCounter + 10;
    }
}
