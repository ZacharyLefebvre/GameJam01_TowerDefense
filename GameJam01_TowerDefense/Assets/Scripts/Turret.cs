using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    #region Turret ScriptableObject Data
    public Turret_ScriptableObject turretData;

    public Text turretName;
    public Text turretDescription;

    public Text turretHealth;
    public Text turretDamage;
    public Text turretSpeed;
    public Text turretCost;

    public Text turretFireRate;

    public Sprite turretArtwork;
    #endregion

    void Awake ()
    {
        turretName.text = turretData.name;
        turretDescription.text = turretData.description;

        turretHealth.text = turretData.health.ToString();
        turretDamage.text = turretData.damage.ToString();
        turretSpeed.text = turretData.damage.ToString();
        turretCost.text = turretData.cost.ToString();

        turretFireRate.text = turretData.fireRate.ToString();

        turretArtwork = turretData.artwork;
    }

    private void Update()
    {
        // find enemies in range
        // watch the closest one and attack/damage him
    }
}
