using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public static TurretManager Instance { get; private set; }

    [SerializeField] private GameObject turret1_Lvl1;
    [SerializeField] private GameObject turret1_Lvl2;
    [SerializeField] private GameObject turret1_Lvl3;

    [SerializeField] private GameObject turret2_Lvl1;
    [SerializeField] private GameObject turret2_Lvl2;
    [SerializeField] private GameObject turret2_Lvl3;

    [SerializeField] private GameObject turret3_Lvl1;
    [SerializeField] private GameObject turret3_Lvl2;
    [SerializeField] private GameObject turret3_Lvl3;

    [SerializeField] private Turret_ScriptableObject turret1Data;
    [SerializeField] private Turret_ScriptableObject turret2Data;
    [SerializeField] private Turret_ScriptableObject turret3Data;

    private int turret1Cost_Lvl1;
    private int turret2Cost_Lvl1;
    private int turret3Cost_Lvl1;

    private int turret1Cost_Lvl2;
    private int turret2Cost_Lvl2;
    private int turret3Cost_Lvl2;

    private int turret1Cost_Lvl3;
    private int turret2Cost_Lvl3;
    private int turret3Cost_Lvl3;

    private int playerCurrentMoney = 0;

    private GameObject currentHexagon = null;
    private Hexagon currentHexagonScript = null;

    [SerializeField] private GameObject TurretUI;
    [SerializeField] private GameObject TurretUpgradeLvl2UI;
    [SerializeField] private GameObject TurretUpgradeLvl3UI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        turret1Cost_Lvl1 = turret1Data.costLvl1;
        turret2Cost_Lvl1 = turret2Data.costLvl1;
        turret3Cost_Lvl1 = turret3Data.costLvl1;

        turret1Cost_Lvl2 = turret1Data.costLvl2;
        turret2Cost_Lvl2 = turret2Data.costLvl2;
        turret3Cost_Lvl2 = turret3Data.costLvl2;

        turret1Cost_Lvl3 = turret1Data.costLvl3;
        turret2Cost_Lvl3 = turret2Data.costLvl3;
        turret3Cost_Lvl3 = turret3Data.costLvl3;

        playerCurrentMoney = Player.Instance.playerMoney;
    }

    // LVL 1
    public void PutTurret1_Lvl1()
    {
        Debug.Log("turret1_Lvl1");
        if (currentHexagonScript.hasTurretLvl1)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
        Instantiate(turret1_Lvl1, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret1Cost_Lvl1);

        currentHexagonScript.HasTurret();
        currentHexagonScript.hasTurretLvl1 = true;
        currentHexagonScript.hasTurret1 = true;

        TurretUI.SetActive(false);
    }

    public void PutTurret2_Lvl1()
    {
        if (currentHexagonScript.hasTurretLvl1)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
            Instantiate(turret2_Lvl1, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret2Cost_Lvl1);

        currentHexagonScript.HasTurret();
        currentHexagonScript.hasTurretLvl1 = true;
        currentHexagonScript.hasTurret2 = true;

        TurretUI.SetActive(false);
    }

    public void PutTurret3_Lvl1()
    {
        Debug.Log("turret3_Lvl1");
        if (currentHexagonScript.hasTurretLvl1)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
            Instantiate(turret3_Lvl1, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret3Cost_Lvl1);

        currentHexagonScript.HasTurret();
        currentHexagonScript.hasTurretLvl1 = true;
        currentHexagonScript.hasTurret3 = true;

        TurretUI.SetActive(false);
    }


    // LVL 2
    public void PutTurret1_Lvl2()
    {
        Debug.Log("turret1_Lvl2");
        if (currentHexagonScript.hasTurretLvl2)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
        {
            // REMOVE LA TOURELLE LVL 1

            if (currentHexagon.transform.childCount != 0)
                Destroy(currentHexagon.transform.GetChild(0).gameObject);
            Instantiate(turret1_Lvl2, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        }
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret1Cost_Lvl2);

        currentHexagonScript.hasTurretLvl1 = false;
        currentHexagonScript.hasTurretLvl2 = true;

        TurretUpgradeLvl2UI.SetActive(false);
    }

    public void PutTurret2_Lvl2()
    {
        Debug.Log("turret2_Lvl2");
        if (currentHexagonScript.hasTurretLvl2)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
        {
            // REMOVE LA TOURELLE LVL 1
            if (currentHexagon.transform.childCount != 0)
                Destroy(currentHexagon.transform.GetChild(0).gameObject);

            Instantiate(turret2_Lvl2, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        }
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret2Cost_Lvl2);

        currentHexagonScript.hasTurretLvl1 = false;
        currentHexagonScript.hasTurretLvl2 = true;

        TurretUpgradeLvl2UI.SetActive(false);
    }

    public void PutTurret3_Lvl2()
    {
        Debug.Log("turret3_Lvl2");
        if (currentHexagonScript.hasTurretLvl2)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
        {
            // REMOVE LA TOURELLE LVL 1
            if (currentHexagon.transform.childCount != 0)
                Destroy(currentHexagon.transform.GetChild(0).gameObject);

            Instantiate(turret3_Lvl2, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        }
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret3Cost_Lvl2);

        currentHexagonScript.hasTurretLvl1 = false;
        currentHexagonScript.hasTurretLvl2 = true;

        TurretUpgradeLvl2UI.SetActive(false);
    }

    // LVL 3
    public void PutTurret1_Lvl3()
    {
        Debug.Log("turret1_Lvl3");
        if (currentHexagonScript.hasTurretLvl3)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
        {
            // REMOVE LA TOURELLE LVL 2
            if (currentHexagon.transform.childCount != 0)
                Destroy(currentHexagon.transform.GetChild(0).gameObject);

            Instantiate(turret1_Lvl3, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        }
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret1Cost_Lvl3);

        currentHexagonScript.hasTurretLvl2 = false;
        currentHexagonScript.hasTurretLvl3 = true;

        TurretUpgradeLvl3UI.SetActive(false);
    }

    public void PutTurret2_Lvl3()
    {
        Debug.Log("turret2_Lvl3");
        if (currentHexagonScript.hasTurretLvl3)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
        {
            // REMOVE LA TOURELLE LVL 2
            if (currentHexagon.transform.childCount != 0)
                Destroy(currentHexagon.transform.GetChild(0).gameObject);

            Instantiate(turret2_Lvl3, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        }
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret2Cost_Lvl3);

        currentHexagonScript.hasTurretLvl2 = false;
        currentHexagonScript.hasTurretLvl3 = true;

        TurretUpgradeLvl3UI.SetActive(false);
    }

    public void PutTurret3_Lvl3()
    {
        Debug.Log("turret3_Lvl3");
        if (currentHexagonScript.hasTurretLvl3)
        {
            Debug.Log("PROBLEME");
            return;
        }

        if (currentHexagon != null)
        {
            // REMOVE LA TOURELLE LVL 2
            if (currentHexagon.transform.childCount != 0)
                Destroy(currentHexagon.transform.GetChild(0).gameObject);

            Instantiate(turret3_Lvl3, currentHexagon.transform.position, currentHexagon.transform.rotation, currentHexagon.transform);
        }
        else
            Debug.Log("PROBLEME");

        Player.Instance.SetPlayerMoney(- turret3Cost_Lvl3);

        currentHexagonScript.hasTurretLvl2 = false;
        currentHexagonScript.hasTurretLvl3 = true;

        TurretUpgradeLvl3UI.SetActive(false);
    }

    public void SetCurrentHexagon(GameObject _currentHexagon)
    {
        currentHexagon = _currentHexagon;
        currentHexagonScript = currentHexagon.GetComponent<Hexagon>();
    }
}
