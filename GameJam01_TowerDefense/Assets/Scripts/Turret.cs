using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turret : MonoBehaviour
{
    #region Turret ScriptableObject Data
    public Turret_ScriptableObject turretData;

    private int turretDamage;
    private int turretRangeText;
    private int turretCost;

    private float turretFireRate;
    #endregion

    public string enemyTag = "Enemy";

    private int turretRange = 5;

    public Transform target = null;

    void Awake ()
    {
        turretCost = turretData.cost;
        turretDamage = turretData.damage;
        turretRange = turretData.range;

        turretFireRate = turretData.fireRate;
    }

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0, .5f);
    }

    private void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector2 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, 0, rotation.x + 90);
        // transform.Rotate(, 0, 0);
        
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
            // LookTowardsTarget(target);
        }
        else
        {
            // évite que la tourelle regarde l'enemy qui sort de sa range
            target = null;
        }
    }

    // public void LookTowardsTarget(Transform enemy)
    // {
    //     transform.LookAt(enemy.transform);
    // }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
