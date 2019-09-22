using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyDisplayText;
    public int initialPlayerMoney = 100;

    public static MoneyDisplay Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        moneyDisplayText.text = initialPlayerMoney.ToString();
    }

    public void UpdateMoneyDisplay(int moneyLeft)
    {
        moneyDisplayText.text = moneyLeft.ToString();
    }
}
