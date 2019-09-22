using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TurretLvl3Management : MonoBehaviour
{
    [SerializeField] private GameObject turret1Lvl3Display;
    [SerializeField] private GameObject turret2Lvl3Display;
    [SerializeField] private GameObject turret3Lvl3Display;

    [SerializeField] private GameObject turret1BUYButtonDisplay;
    [SerializeField] private GameObject turret2BUYButtonDisplay;
    [SerializeField] private GameObject turret3BUYButtonDisplay;

    [SerializeField] private GameObject turret1Description;
    [SerializeField] private GameObject turret2Description;
    [SerializeField] private GameObject turret3Description;

    [SerializeField] private GameObject spellsUI;

    private int hexagonTurretNumber;

    private bool timeSlowerBool = false;

    private void Awake()
    {
        timeSlowerBool = TimeManager.Instance.triggerPermaSlowTime;
    }

    private void OnEnable()
    {
        timeSlowerBool = true;
        spellsUI.SetActive(false);
    }

    private void OnDisable()
    {
        if (turret1Lvl3Display.activeSelf)
        {
            turret1Lvl3Display.SetActive(false);
            turret1BUYButtonDisplay.SetActive(false);
            turret1Description.SetActive(false);
        }

        if (turret2Lvl3Display.activeSelf)
        {
            turret2Lvl3Display.SetActive(false);
            turret2BUYButtonDisplay.SetActive(false);
            turret2Description.SetActive(false);
        }

        if (turret3Lvl3Display.activeSelf)
        {
            turret3Lvl3Display.SetActive(false);
            turret3BUYButtonDisplay.SetActive(false);
            turret3Description.SetActive(false);
        }

        timeSlowerBool = false;
        spellsUI.SetActive(true);
    }

    // DOIT ENCORE ETRE CALL!!
    public void SetHexagonTurretNumber(int turretType)
    {
        if (turretType == 1)
        {
            turret1Lvl3Display.SetActive(true);
            turret1BUYButtonDisplay.SetActive(true);
            turret1Description.SetActive(true);
        }

        if (turretType == 2)
        {
            turret2Lvl3Display.SetActive(true);
            turret2BUYButtonDisplay.SetActive(true);
            turret2Description.SetActive(true);
        }

        if (turretType == 3)
        {
            turret3Lvl3Display.SetActive(true);
            turret3BUYButtonDisplay.SetActive(true);
            turret3Description.SetActive(true);
        }
    }
}
