﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private GameObject turret01;
    [SerializeField] private GameObject turret02;
    [SerializeField] private GameObject turret03;

    public void PutTurret01()
    {
        // check que le player a assez de thunes
        // récupérer l'endroit du clic du player
        // s'assurer qu'il y a la place pour construire une tourelle


        Instantiate(turret01);
    }
}