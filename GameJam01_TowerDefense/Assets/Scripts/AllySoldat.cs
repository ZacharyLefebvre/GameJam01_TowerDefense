using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySoldat : MonoBehaviour
{
    public float health = 10;
    public float Range = .5f;
    public float speed = 3f;
    public int Damage = 2;
    public float AttackSpeed = 0.5f;

    private int EnemyLayer = 1 << 9;

    public Collider[] hitColliders;

    private Transform target = null;
    private Transform hexagonTarget = null;

    private Vector3 dir;

    private bool pathReached = false;

    private void Start()
    {
        InvokeRepeating("Attack", 0, AttackSpeed);
    }

    // a mon moi du futur, j'ai créé hexagonTarget pour pouvoir toujours revenir vers l'hexagon initial ()mais attention 
    // au risque qu'il traverse les tourelles

    void Update()
    {
        if (health <= 0)
        {
            //Son de mort ?
            Destroy(gameObject);
        }

        // il sort de la caserne, va au path le plus proche puis il bouge plus (c'est le mieux que je sais faire a 5h du mat)
        if (pathReached)
            return;

        if (target != null)
            dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            pathReached = true;
        }
    }
    public void AddDamage(int Damage)
    {
        health -= Damage;
    }

    private void Attack()
    {
        hitColliders = Physics.OverlapSphere(transform.position, Range, EnemyLayer);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].gameObject.GetComponent<Enemy>().AddDamage(Damage);
            i++;
        }
    }

    public void SetSoldierTarget(Transform _target)
    {
        hexagonTarget = _target;
        target = _target;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
