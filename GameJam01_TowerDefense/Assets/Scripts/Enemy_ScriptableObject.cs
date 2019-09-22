using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy_ScriptableObject : ScriptableObject
{
    public GameObject oxygen;
    public new string name;
    public string description;

    public int health;
    public int damage;
    public int speed;
    public int expDropped;
    public float range;
    public float AttackSpeed;

    public bool canFly;
}
