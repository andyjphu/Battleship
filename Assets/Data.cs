using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Data : MonoBehaviour
{
    public List<GameObject> selectedObjects = new List<GameObject>();
    public int ordersLeft = 0, money = 0, turn = 0, ordersIncome=0, moneyIncome = 0;
    public GameObject StatsDisplay;
    public GameObject ConsoleDisplay; 
    // Start is called before the first frame update
    void Start()
    {
        SetConsoleDisplayMessage("Hi im the console: Click on the red soldier to get started");
        SetStatsDisplayMessage("Money: " + money + " \n Turn: " + turn + " \n Orders Left: " + ordersLeft);
    }

    public void AdjustOrdersLeft(int AdjustBy)
    {
        ordersLeft += AdjustBy; 
        StatsDisplay.GetComponent<TMP_Text>().text = "Money: "+money+" \n Turn: "+turn+" \n Orders Left: " + ordersLeft;
    }

    public void AdjustMoney(int AdjustBy)
    {
        money += AdjustBy;
    }

    public void AdjustTurn(int AdjustBy)
    {
        turn += AdjustBy;
    }
    public void SetConsoleDisplayMessage(string message) 
    {
        ConsoleDisplay.GetComponent<TMP_Text>().text = message;
    }
    public void SetStatsDisplayMessage(string message)
    {
        StatsDisplay.GetComponent<TMP_Text>().text = message;
    }
    // Update is called once per frame
    public void Update()
    {
        
    }
}
