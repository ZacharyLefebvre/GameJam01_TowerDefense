using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class Turret_ScriptableObject : ScriptableObject
{
    public new string name;

    public int health;
    public int damage;
    public int range;

    public float fireRate;

    /*
    // à voir
    public bool canFreeze;
    public bool canPoison;
    ...
    */
}
