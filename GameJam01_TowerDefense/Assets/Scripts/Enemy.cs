using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player playerScript;

    #region Enemy ScriptableObject Data
    public Enemy_ScriptableObject enemyData;

    // public Text enemyName;
    // public Text enemyDescription;

    private int health;
    private int damage;
    private int speed;

    public bool canFly;
    #endregion

    private Transform target;
    private int waypointIndex = 0;

    private void Awake()
    {
        health = enemyData.health;
        damage = enemyData.damage;
        speed = enemyData.speed;

        canFly = enemyData.canFly;
    }

    private void Start()
    {
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f )
        {
            Debug.Log("objectif atteint");
            GoToNextWaypoint();
        }
    }

    private void GoToNextWaypoint()
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
        {
            // atteint la fin du parcours!
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = WayPoints.points[waypointIndex];
    }
}
