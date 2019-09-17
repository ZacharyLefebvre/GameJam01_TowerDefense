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

    public TextMeshProUGUI turretDamage;
    public TextMeshProUGUI turretRangeText;
    public TextMeshProUGUI turretCost;

    public TextMeshProUGUI turretFireRate;

    public Image turretArtwork;
    #endregion

    void Awake()
    {
        turretName.text = turretData.name;
        turretDescription.text = turretData.description;

        turretDamage.text = turretData.damage.ToString();

        turretRangeText.text = turretData.range.ToString();

        turretCost.text = turretData.cost.ToString();

        turretFireRate.text = turretData.fireRate.ToString();

        turretArtwork.sprite = turretData.artwork;
    }
}
