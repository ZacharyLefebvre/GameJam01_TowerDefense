using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanceler : MonoBehaviour
{
    [SerializeField] private GameObject TurretsUI;

    private void OnMouseDown()
    {
        Debug.Log("Vire moi l'UI PUTAIN");
        TurretsUI.SetActive(false);
    }
}
