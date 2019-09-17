﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player playerScript;

    public Enemy_ScriptableObject enemyData;

    public Text enemyNameText;
    public Text enemyDescription;

    public Text enemyHealth;
    public Text enemyDamage;
    public Text enemySpeed;
    public Text enemyCost;

    public Sprite enemyArtwork;

    public bool canFly;

    private void Awake()
    {
        enemyNameText.text = enemyData.name;
        enemyDescription.text = enemyData.description;

        enemyCost.text = enemyData.cost.ToString();
        enemyHealth.text = enemyData.health.ToString();
        enemySpeed.text = enemyData.damage.ToString();

        enemyArtwork = enemyData.artwork;

        canFly = enemyData.canFly;
    }

    private void Update()
    {
        // quel type de déplacement va-t-on utiliser?
    }
}
