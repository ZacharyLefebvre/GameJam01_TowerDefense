using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherProjectil : MonoBehaviour
{
    private Transform targetenemy;
    private float speed = 3f;
    private int Damage = 3;

    void Update()
    {
        if (targetenemy != null)
        {
            Vector3 dir = targetenemy.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(dir);
            if (dir.magnitude < 0.1f)
            {
                targetenemy.GetComponent<Enemy>().AddDamage(Damage);
                Destroy(gameObject);
            }
        }
    }
    public void givetarget(Transform target)
    {
        targetenemy = target;
    }
}
