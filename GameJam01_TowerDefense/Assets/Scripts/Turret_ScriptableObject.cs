using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret")]
public class Turret_ScriptableObject : ScriptableObject
{
    public new string name;
    public string description;

    public int damage;
    public int range;
    public int cost;

    public float fireRate;

    public Sprite artwork;

    public bool aoe;

    /*
    // à voir
    public bool canFreeze;
    public bool canPoison;
    ...
    */
}
