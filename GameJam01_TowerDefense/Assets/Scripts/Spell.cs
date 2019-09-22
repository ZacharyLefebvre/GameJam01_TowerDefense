using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public string turretTag = "Turret";
    public float freezeTime = 5;
    public float freezeForce = 4;
    public float boostTime = 5;
    public float boostForce = 2;


    public void FreezeEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemy>().FreezeForSecond(freezeForce, freezeTime);
        }
    }


    public void BoostTurret()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag(turretTag);
        foreach (GameObject turret in turrets)
        {
            turret.GetComponent<Turret>().BoostForSecond(boostForce, boostTime);
        }
    }
}
