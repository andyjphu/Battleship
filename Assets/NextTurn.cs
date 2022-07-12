using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextTurn : MonoBehaviour
{
    Data data; 
    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Player").GetComponent<Data>();
        gameObject.GetComponent<Button>().onClick.AddListener(GoToNextTurn) ;
    }

    // Update is called once per frame
    void Update()
    {

    }

   

    void GoToNextTurn()
    { 
        data.AdjustTurn(1);
        data.AdjustMoney(data.moneyIncome);
        data.AdjustOrdersLeft(data.ordersIncome);
    }
}
