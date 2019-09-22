using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hexagon : MonoBehaviour
{
    public static Hexagon Instance { get; private set; }

    [SerializeField] private UI_TurretLvl2Management UI_TurretsLvl2Script;
    [SerializeField] private UI_TurretLvl3Management UI_TurretsLvl3Script;

    private bool hasTurret = false;

    public bool hasTurretLvl1 = false;
    public bool hasTurretLvl2 = false;
    public bool hasTurretLvl3 = false;

    public bool hasTurret1 = false;
    public bool hasTurret2 = false;
    public bool hasTurret3 = false;

    public bool canBuild = true; // juste pour cases "cutées" aux bords de l'écran

    private int playerMoney;

    private Material hexMat;

    private Color hexInitialColor;
    public Color greenColor;
    public Color redColor;
    public Color hasTurretColor;

    private Renderer rend;

    [SerializeField] private GameObject turretsUI;
    [SerializeField] private GameObject turretsUpgradeLvl2UI;
    [SerializeField] private GameObject turretsUpgradeLvl3UI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        rend = transform.GetComponent<MeshRenderer>();
        hexMat = rend.material;
        hexInitialColor = hexMat.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (!hasTurret && canBuild)
            {
                DisplayTurretsUI();
                TurretManager.Instance.SetCurrentHexagon(gameObject);
            }
            else if (hasTurretLvl1)
            {
                // send to UI lvl 2 manager
                if (hasTurret1)
                    UI_TurretsLvl2Script.SetHexagonTurretNumber(1);
                if (hasTurret2)
                    UI_TurretsLvl2Script.SetHexagonTurretNumber(2);
                if (hasTurret3)
                    UI_TurretsLvl2Script.SetHexagonTurretNumber(3);

                TurretManager.Instance.SetCurrentHexagon(gameObject);
                DisplayTurretsUpgradeLvl2UI();
            }
            else if (hasTurretLvl2)
            {
                // send to UI lvl 3 manager
                if (hasTurret1)
                    UI_TurretsLvl3Script.SetHexagonTurretNumber(1);
                if (hasTurret2)
                    UI_TurretsLvl3Script.SetHexagonTurretNumber(2);
                if (hasTurret3)
                    UI_TurretsLvl3Script.SetHexagonTurretNumber(3);

                TurretManager.Instance.SetCurrentHexagon(gameObject);

                DisplayTurretsUpgradeLvl3UI();
            }
            else if (hasTurretLvl3)
                return;
        }
        hexMat.color = hexInitialColor;
    }

    private void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        rend.enabled = true;

        if (!hasTurretLvl3 && canBuild)
        {
            hexMat.color = greenColor;
        }
        else if(!canBuild)
        {
            hexMat.color = redColor;
        }
        else if(hasTurretLvl3)
        {
            hexMat.color = hasTurretColor;
        }
    }

    private void OnMouseExit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        rend.enabled = false;
    }    

    public void DisplayTurretsUI()
    {
        turretsUI.SetActive(true);
    }

    public void DisplayTurretsUpgradeLvl2UI()
    {
        turretsUpgradeLvl2UI.SetActive(true);
    }

    public void DisplayTurretsUpgradeLvl3UI()
    {
        turretsUpgradeLvl3UI.SetActive(true);
    }

    public void HasTurret()
    {
        hasTurret = true;
    }
}
