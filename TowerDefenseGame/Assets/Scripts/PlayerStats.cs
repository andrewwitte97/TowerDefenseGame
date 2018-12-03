using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    
    //static variables carry over between scene loads
    //so setting static int money to startMoney would be bad
    public static int Money;
    public int startMoney = 400;

    private void Start()
    {
        Money = startMoney;
    }
    
}
