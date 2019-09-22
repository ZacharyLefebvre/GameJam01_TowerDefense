using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TurretLvl1Management : MonoBehaviour
{
    [SerializeField] private GameObject spellsUI;

    private void OnEnable()
    {
        TimeManager.Instance.triggerPermaSlowTime = true;
        spellsUI.SetActive(false);
    }

    private void OnDisable()
    {
        TimeManager.Instance.triggerPermaSlowTime = false;
        spellsUI.SetActive(true);
    }
}
