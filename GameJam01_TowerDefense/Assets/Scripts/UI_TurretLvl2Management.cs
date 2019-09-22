using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TurretLvl2Management : MonoBehaviour
{
    [SerializeField] private GameObject turret1Lvl2Display;
    [SerializeField] private GameObject turret2Lvl2Display;
    [SerializeField] private GameObject turret3Lvl2Display;

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
        if (turret1Lvl2Display.activeSelf)
        {
            turret1Lvl2Display.SetActive(false);
            turret1BUYButtonDisplay.SetActive(false);
            turret1Description.SetActive(false);
        }

        if (turret2Lvl2Display.activeSelf)
        {
            turret2Lvl2Display.SetActive(false);
            turret2BUYButtonDisplay.SetActive(false);
            turret2Description.SetActive(false);
        }

        if (turret3Lvl2Display.activeSelf)
        {
            turret3Lvl2Display.SetActive(false);
            turret3BUYButtonDisplay.SetActive(false);
            turret2Description.SetActive(false);
        }
        spellsUI.SetActive(true);

        timeSlowerBool = false;
    }

    public void SetHexagonTurretNumber(int turretType)
    {
        if (turretType == 1)
        {
            turret1Lvl2Display.SetActive(true);
            turret1BUYButtonDisplay.SetActive(true);
            turret1Description.SetActive(true);
        }

        if (turretType == 2)
        {
            turret2Lvl2Display.SetActive(true);
            turret2BUYButtonDisplay.SetActive(true);
            turret2Description.SetActive(true);
        }

        if (turretType == 3)
        {
            turret3Lvl2Display.SetActive(true);
            turret3BUYButtonDisplay.SetActive(true);
            turret3Description.SetActive(true);
        }
    }
}
