using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class Turret_ScriptableObject : ScriptableObject
{
    public GameObject allysoldat;
    public GameObject allyarcher;
    public GameObject archerprojectil;
    public GameObject canonProjectil;

    public new string name;
    public string description;

    public int damageLvl1;
    public int damageLvl2;
    public int damageLvl3;

    public int rangeLvl1;
    public int rangeLvl2;
    public int rangeLvl3;

    public int costLvl1;
    public int costLvl2;
    public int costLvl3;

    public float fireRateLvl1;
    public float fireRateLvl2;
    public float fireRateLvl3;
    public int MaxSoldat;

    public bool canon;
    public bool archer;
    public bool soldat;

    /*
    // à voir
    public bool canFreeze;
    public bool canPoison;
    ...
    */
}
