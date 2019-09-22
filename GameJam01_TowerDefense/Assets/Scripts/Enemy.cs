using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region Enemy ScriptableObject Data
    public Enemy_ScriptableObject enemyData;

    // public Text enemyName;
    // public Text enemyDescription;

    private int health;
    private int damage;
    private float speed;
    private int expDropped;
    private float range;
    private float AttackSpeed;
    public bool canFly;
    #endregion

    private Transform target;
    private int waypointIndex = 0;

    public GameObject oxygen;
    private int AllyLayer = 1 << 10;

    private float lastTime = 0;

    private bool canDropO2 = true;

    private float normalSpeed;

    [SerializeField] private Color frozenColor;

    private void Awake()
    {
        health = enemyData.health;
        damage = enemyData.damage;
        range = enemyData.range;
        AttackSpeed = enemyData.AttackSpeed;
        speed = enemyData.speed;
        expDropped = enemyData.speed;

        canFly = enemyData.canFly;
    }

    private void Start()
    {
        target = WayPoints.points[0];
        InvokeRepeating("Attack", 0, AttackSpeed);

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GoToNextWaypoint();
        }

        if (health <= 0)
        {
            Instantiate(oxygen, transform.position, transform.rotation);

            //Son de mort ?
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        if (canDropO2)
            Player.Instance.SetPlayerMoney(expDropped);
    }

    private void GoToNextWaypoint()
    {
        if (waypointIndex >= WayPoints.points.Length - 1)
        {
            // atteint la fin du parcours!
            Player.Instance.DamagePlayer(1);
            GameManager.Instance.CameraShake();

            // don't drop O2
            canDropO2 = false;

            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = WayPoints.points[waypointIndex];
    }

    public void AddDamage(int Damage)
    {
        health -= Damage;
    }

    private void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range, AllyLayer);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Debug.Log("degats");
            hitColliders[i].GetComponent<AllySoldat>().AddDamage(damage);
            i++;
        }
    }

    public void FreezeForSecond(float freezeForce, float freezeTime)
    {
        SpriteRenderer enemyRend = GetComponent<SpriteRenderer>();
        enemyRend.color = frozenColor;

        normalSpeed = speed;
        if (freezeForce != 0)
            speed = speed / freezeForce;
        StartCoroutine(WaitEndOfFreeze(freezeTime, enemyRend));
    }

    IEnumerator WaitEndOfFreeze(float freezeTime, SpriteRenderer rend)
    {
        yield return new WaitForSeconds(freezeTime);
        rend.color = Color.white;
        speed = normalSpeed;
    }
}
