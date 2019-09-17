using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy01;
    [SerializeField] private GameObject enemy02;
    [SerializeField] private GameObject enemy03;

    void Start()
    {
        Instantiate(enemy01, transform.position, transform.rotation);
    }

    void Update()
    {
        
    }
}
