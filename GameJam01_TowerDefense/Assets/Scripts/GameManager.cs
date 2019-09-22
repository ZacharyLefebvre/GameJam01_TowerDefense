using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject turretOnBattlefield;

    private bool noTurretYet = true;

    public string turretTag = "Turret";

    // camera shake
    public float Magn;
    public float Rough;
    public float FadeIn;
    public float Fadeout;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (noTurretYet)
        {
            turretOnBattlefield = GameObject.FindGameObjectWithTag(turretTag);
            if (turretOnBattlefield != null)
            {
                Debug.Log("tourelle posée");
                noTurretYet = false;
                WaveGenerator.Instance.CanStartSpawning();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Exit>().ExitGame();
        }
    }


    public void CameraShake()
    {
        CameraShaker.Instance.ShakeOnce(Magn, Rough, FadeIn, Fadeout);
    }
}
