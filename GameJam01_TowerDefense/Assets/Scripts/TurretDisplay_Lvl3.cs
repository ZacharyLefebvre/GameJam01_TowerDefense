using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretDisplay_Lvl3 : MonoBehaviour
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
        turretName.text = turretData.name + " Level 3";
        turretDescription.text = turretData.description;

        turretCost.text = turretData.costLvl3.ToString();

        turretDamage.text = "Damage : " + turretData.damageLvl2.ToString() + "+ " + turretData.damageLvl3.ToString();

        turretRangeText.text = "Range : " + turretData.rangeLvl2.ToString() + "+ " + turretData.rangeLvl3.ToString();

        turretFireRate.text = "FireRate : " + turretData.fireRateLvl2.ToString() + " /s" + "+ " + turretData.fireRateLvl3.ToString();
    }
}
