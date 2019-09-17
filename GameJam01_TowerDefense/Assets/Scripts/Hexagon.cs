using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hexagon : MonoBehaviour
{
    private bool hasTurret = false;

    private bool hasTurretLvl1 = false;
    private bool hasTurretLvl2 = false;
    private bool hasTurretLvl3 = false;

    public bool canBuild = true; // juste pour cases "cutées" aux bords de l'écran

    private int playerMoney;

    private Material hexMat;

    private Color hexInitialColor;
    public Color greenColor;
    public Color redColor;
    public Color hasTurretColor;

    private Renderer rend;

    [SerializeField] private GameObject turretsUI;

    private void Start()
    {
        rend = transform.GetComponent<MeshRenderer>();
        hexMat = rend.material;
        hexInitialColor = hexMat.color;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!hasTurret && canBuild)
            {
                DisplayTurretsUI();
                Debug.Log(transform.position);
            }
            else
            {
                // peut pas construire (expliquer pq?)
            }
        }
    }

    private void OnMouseOver()
    {
        rend.enabled = true;

        // + has enough money!
        if (!hasTurret && canBuild)
        {
            hexMat.color = greenColor;
        }
        else
        {
            hexMat.color = redColor;
        }
    }

    private void OnMouseExit()
    {
        rend.enabled = false;
    }    

    public void DisplayTurretsUI()
    {
        turretsUI.SetActive(true);
    }

    private void HasTurret()
    {
        hexMat.color = hasTurretColor;
    }
}
