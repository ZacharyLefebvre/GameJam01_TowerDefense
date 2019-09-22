using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private HpDisplay hpDisplayScript;
    [SerializeField] private GameOver gameOverScript;

    public int playerHealth = 100;

    public int playerMoney = 100;

	void Awake ()
    {
        Instance = this;
    }

    public void DamagePlayer(int damageTaken)
    {
        playerHealth -= damageTaken;
        hpDisplayScript.UpdateHpAmount(playerHealth);
        if (playerHealth <= 0)
        {
            // GAMEOVER
            gameOverScript.GameOverMethod();
        }
    }

    // peut être négatif ou positif selon le signe du int parameter
    public void SetPlayerMoney(int moneyChange)
    {
        playerMoney += moneyChange;

        // update visual amount of money
        MoneyDisplay.Instance.UpdateMoneyDisplay(playerMoney);
    }
}
