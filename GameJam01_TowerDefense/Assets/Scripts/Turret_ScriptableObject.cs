using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class Enemy_ScriptableObject1 : ScriptableObject
{
    public new string name;

    public int health;
    public int damage;

    public float fireRate;

    /*
    // à voir
    public bool canFreeze;
    */
}
