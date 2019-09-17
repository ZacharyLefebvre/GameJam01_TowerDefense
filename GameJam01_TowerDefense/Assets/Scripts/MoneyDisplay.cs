using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    private TextMeshProUGUI moneyDisplayText;

    void UpdateMoneyDisplay(int moneyLeft)
    {
        moneyDisplayText.text = moneyLeft.ToString();
    }
}
