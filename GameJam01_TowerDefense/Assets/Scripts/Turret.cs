using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turret : MonoBehaviour
{
    #region Turret ScriptableObject Data
    public Turret_ScriptableObject turretData;

    public TextMeshProUGUI turretName;
    public TextMeshProUGUI turretDescription;

    public TextMeshProUGUI turretDamage;
    public TextMeshProUGUI turretRangeText;
    public TextMeshProUGUI turretCost;

    public TextMeshProUGUI turretFireRate;

    public Image turretArtwork;
    #endregion

    public string enemyTag = "Enemy";

    private int turretRange;

    private Transform target = null;

    void Awake ()
    {
        turretName.text = turretData.name;
        turretDescription.text = turretData.description;

        turretDamage.text = "Damage : " + turretData.damage.ToString();

        turretRange = turretData.range;
        turretRangeText.text = "Range : " + turretRange.ToString();

        turretCost.text = "Cost : " + turretData.cost.ToString();

        turretFireRate.text = "FireRate : " + turretData.fireRate.ToString();

        turretArtwork.sprite = turretData.artwork;
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

        transform.LookAt(target);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
