using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player playerScript;

    // public event EnemyToTheEnd;

    private void Awake()
    {
        playerScript = Player.Instance;
    }
}
