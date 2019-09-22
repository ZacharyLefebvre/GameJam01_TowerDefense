using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonProjectil : MonoBehaviour
{
    private Transform targetenemy;
    public float speed = 3f;
    public int Damage = 5;
    public float Range = 4f;
    public int EnemyLayer;

    void Update()
    {
        if (targetenemy != null)
        {
            Vector3 dir = targetenemy.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(dir);
            if (dir.magnitude < 0.1f)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, Range, EnemyLayer);
                int i = 0;
                while (i < hitColliders.Length)
                {
                    hitColliders[i].GetComponent<Enemy>().AddDamage(Damage);
                    i++;
                }
                Destroy(gameObject);
            }
        }
    }
    public void givetarget(Transform target)
    {
        targetenemy = target;
    }
}
