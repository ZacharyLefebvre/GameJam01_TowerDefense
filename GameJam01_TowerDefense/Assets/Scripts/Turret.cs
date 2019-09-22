using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turret : MonoBehaviour
{
    #region Turret ScriptableObject Data
    public Turret_ScriptableObject turretData;

    private GameObject allysoldat;
    private GameObject archerProjectil;
    private GameObject archerprojectil;
    private GameObject canonProjectil;

    private int turretCost;
    private float turretDamage;
    private int turretRangeText;
    private int turretRange = 5;

    private int MaxSoldat;

    private float turretFireRate;

    private bool cannon;
    private bool archer;
    // private float turnSpeed = 35;
    #endregion

    private float normalDamage;

    private float lastTime = 0;
    private float currentsoldatNbr = 0;
    public string enemyTag = "Enemy";

    public static Turret Instance { get; private set; }

    public Transform target = null;

    void Awake ()
    {
        Instance = this;

        turretCost = turretData.costLvl1;
        turretDamage = turretData.damageLvl1;
        turretRange = turretData.rangeLvl1;
        MaxSoldat = turretData.MaxSoldat;
        turretFireRate = turretData.fireRateLvl1;

        cannon = turretData.canon;
        archer = turretData.archer;
        canonProjectil = turretData.canonProjectil;
        archerProjectil = turretData.archerprojectil; // juste le sprite les tire se font par la tourelle
        allysoldat = turretData.allysoldat;
    }

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0, .3f);

        InvokeRepeating("Attack", 0, turretFireRate);
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        // look at the right orientation
        Vector2 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        // Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0, 0, rotation.x + 90);
    }

    private void Attack()
    {
        if (cannon)
        {
            var projectil = Instantiate(canonProjectil, transform.position, transform.rotation);
            projectil.GetComponent<CanonProjectil>().givetarget(target);
        }
        else if (archer)
        {
            var archerspawn = Instantiate(archerProjectil, transform.position, transform.rotation);
            archerspawn.GetComponent<ArcherProjectil>().givetarget(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float enemyDistance = Vector2.Distance(transform.position, enemy.transform.position);

            if (enemyDistance < shortestDistance)
            {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }

        // if enemy found && he is in range of the turret
        if (nearestEnemy != null && shortestDistance <= turretRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            // évite que la tourelle regarde l'enemy qui sort de sa range
            target = null;
        }
    }

    public void BoostForSecond(float boostforce, float boostTime)
    {
        normalDamage = turretDamage;
        turretDamage *= boostforce;
        StartCoroutine(WaitEndOfBoost(boostTime));
    }

    IEnumerator WaitEndOfBoost(float boostTime)
    {
        yield return new WaitForSeconds(boostTime);
        turretDamage = normalDamage;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
