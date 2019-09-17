using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject turret01;
    [SerializeField] private GameObject turret02;
    [SerializeField] private GameObject turret03;

    [SerializeField] private Turret_ScriptableObject turret1Data;
    [SerializeField] private Turret_ScriptableObject turret2Data;
    [SerializeField] private Turret_ScriptableObject turret3Data;

    public GameObject currentHexagon = null;

    public void PutTurret01()
    {
        // check que le player a assez de thunes
        // récupérer l'endroit du clic du player
        // s'assurer qu'il y a la place pour construire une tourelle

        if (currentHexagon != null)
        Instantiate(turret01, currentHexagon.transform.position, currentHexagon.transform.rotation);
        else
            Debug.Log("PROBLEME");
    }

    public void PutTurret02()
    {
        if (currentHexagon != null)
            Instantiate(turret02, currentHexagon.transform.position, currentHexagon.transform.rotation);
        else
            Debug.Log("PROBLEME");
    }

    public void PutTurret03()
    {
        if (currentHexagon != null)
            Instantiate(turret03, currentHexagon.transform.position, currentHexagon.transform.rotation);
        else
            Debug.Log("PROBLEME");
    }

    public void SetCurrentHexagon(GameObject _currentHexagon)
    {
        currentHexagon = _currentHexagon;
    }
}
