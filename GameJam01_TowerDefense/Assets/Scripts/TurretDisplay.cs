using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretDisplay : MonoBehaviour
{

    #region Turret ScriptableObject Data
    public Turret_ScriptableObject turretData;

    public TextMeshProUGUI turretName;
    public TextMeshProUGUI turretDescription;

    public TextMeshProUGUI turretCost;
    public TextMeshProUGUI turretDamage;
    public TextMeshProUGUI turretRangeText;

    public TextMeshProUGUI turretFireRate;
    #endregion

    void Awake()
    {
        turretName.text = turretData.name;
        turretDescription.text = turretData.description;

        turretDamage.text = "Damage : " + turretData.damageLvl1.ToString();

        turretRangeText.text = "Range : " + turretData.rangeLvl1.ToString();

        turretCost.text = "Cost : " + turretData.costLvl1.ToString();

        turretFireRate.text = "FireRate : " + turretData.fireRateLvl1.ToString() + " /s";
    }
}
