using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretDisplay_Lvl2 : MonoBehaviour
{
    #region Turret ScriptableObject Data
    public Turret_ScriptableObject turretData;

    // public TextMeshProUGUI turretName;
    public TextMeshProUGUI turretDescription;

    public TextMeshProUGUI turretCost;
    public TextMeshProUGUI turretDamage;
    public TextMeshProUGUI turretRangeText;

    public TextMeshProUGUI turretFireRate;
    #endregion

    void Awake()
    {
        // turretName.text = turretData.name + " Level 2";
        turretDescription.text = turretData.description;
        turretCost.text = "Cost : " + turretData.costLvl2.ToString();

        turretDamage.text = "Damage : " + turretData.damageLvl1.ToString() + "  + " + turretData.damageLvl2.ToString();

        turretRangeText.text = "Range : " + turretData.rangeLvl1.ToString() + "  + " + turretData.rangeLvl2.ToString();

        turretFireRate.text = "FireRate : " + turretData.fireRateLvl1.ToString() + " /s" + "  + " + turretData.fireRateLvl2.ToString();
    }
}
