using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HpDisplayText;
    public int initialPlayerHp = 100;

    public static HpDisplay Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HpDisplayText.text = initialPlayerHp.ToString();
    }

    public void UpdateHpAmount(int HpLeft)
    {
        HpDisplayText.text = HpLeft.ToString();
    }
}
