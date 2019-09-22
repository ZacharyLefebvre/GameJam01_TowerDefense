using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BuyButton : MonoBehaviour
{
    [SerializeField] private Turret_ScriptableObject turretData;

    private int thisButtonTurretCost;

    private bool isInteractable;

    private int playerMoney;

    private void Awake()
    {
        thisButtonTurretCost = turretData.costLvl3;
        isInteractable = transform.GetComponent<Button>().interactable;
    }

    private void OnEnable()
    {
        this.playerMoney = Player.Instance.playerMoney;

        if (playerMoney < thisButtonTurretCost)
            isInteractable = false;
        else
            isInteractable = true;
    }
}
