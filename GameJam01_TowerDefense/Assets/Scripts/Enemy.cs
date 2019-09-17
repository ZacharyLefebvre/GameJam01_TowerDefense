using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player playerScript;

    #region Enemy ScriptableObject Data
    public Enemy_ScriptableObject enemyData;

    public Text enemyName;
    public Text enemyDescription;

    public Text enemyHealth;
    public Text enemyDamage;
    public Text enemySpeed;
    public Text enemyCost;

    public Image enemyArtwork;

    public bool canFly;
    #endregion

    private void Awake()
    {
        enemyName.text = enemyData.name;
        enemyDescription.text = enemyData.description;

        enemyCost.text = enemyData.cost.ToString();
        enemyHealth.text = enemyData.health.ToString();
        enemySpeed.text = enemyData.damage.ToString();

        enemyArtwork.sprite = enemyData.artwork;

        canFly = enemyData.canFly;
    }

    private void Update()
    {
        // quel type de déplacement va-t-on utiliser?
    }
}
