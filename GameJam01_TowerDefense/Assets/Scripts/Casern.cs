using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casern : MonoBehaviour
{
    #region Turret ScriptableObject Data
    public Turret_ScriptableObject turretData;

    private GameObject allysoldat;

    private int turretCost;
    private int turretRangeText;
    private int turretRange = 5;

    private bool cannon;
    private bool archer;
    #endregion

    [SerializeField] private int spawnDelay = 10;

    public Collider[] pathColliders;

    private int pathLayer = 1 << 11;
    public string pathTag = "Path";

    public static Turret Instance { get; private set; }

    public Transform target = null;

    private void Awake()
    {
        turretCost = turretData.costLvl1;
        turretRange = turretData.rangeLvl1;

        allysoldat = turretData.allysoldat;

        // calcul du chemin le plus proche
        #region path computing
        pathColliders = Physics.OverlapSphere(transform.position, turretRange, pathLayer);
        // pathGameObject = GameObject.FindGameObjectsWithTag(pathTag);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestPath = null;

        foreach (Collider path in pathColliders)
        {
            float pathDistance = Vector2.Distance(transform.position, path.transform.position);

            if (pathDistance < shortestDistance)
            {
                shortestDistance = pathDistance;
                nearestPath = path.gameObject;
            }
        }

        // if enemy found && he is in range of the turret
        if (nearestPath != null && shortestDistance <= turretRange)
        {
            target = nearestPath.transform;
        }
        else
        {
            // évite que la tourelle regarde l'enemy qui sort de sa range
            target = null;
        }
        #endregion
    }

    void Start()
    {
        if (target != null)
            InvokeRepeating("SpawnSoldiers", 0f, spawnDelay);
        else
            Debug.Log("pas de target");
    }

    private void SpawnSoldiers()
    {
        GameObject soldierInst = Instantiate(allysoldat, transform.position, transform.rotation);
        soldierInst.GetComponent<AllySoldat>().SetSoldierTarget(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, turretRange);
    }
}
