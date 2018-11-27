using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Money;
	public int startMoney = 400;
    public Text moneyText;

    void Start()
	{
		Money = startMoney;
        moneyText.text = "Money: $" + Money.ToString();
	}

    void Update()
    {
        moneyText.text = "Money: $" + Money.ToString();
    }
}