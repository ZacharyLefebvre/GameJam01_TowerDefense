using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanceler : MonoBehaviour
{
    [SerializeField] public GameObject HiddenUI;

    private void OnMouseDown()
    {
        Debug.Log("Vire moi l'UI PUTAIN");
        HiddenUI.SetActive(false);
    }
}
