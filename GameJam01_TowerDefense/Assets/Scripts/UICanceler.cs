using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanceler : MonoBehaviour
{
    [SerializeField] private GameObject TurretsUI;

    private void OnMouseDown()
    {
        TurretsUI.SetActive(false);
    }
}
