using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    public Transform SpawnPoint;
    public List<GameObject> Enemy = new List<GameObject>();
    public GameObject Boss1;

    public int AnticipationTime = 5;
    public int WaveTurningTime = 5;
    public float TimeBetweenTwoEnemy = 0.3f;
    public int NbrOfWave = 20;
    public int NbrOfEnemyFirstWave = 5;
    public float RatioNbrOfEnemyBetweenTwoWave = 1.2f;
    public int ManyWaveForABoss = 5;


    private float StartTime;
    private int currentWave = 1;
    private int DisplayTime;
    private bool LastWaveFinished = true;
    private bool TimerIsFinished = true;

    void Start()
    {
        StartTime = Time.time;
        LastWaveFinished = false;
        SpawnEnemy();
    }

    void Update()
    {
        if (currentWave < NbrOfWave)
        {
            Debug.Log(currentWave);
            if (LastWaveFinished)
            {
                LastWaveFinished = false;
                DisplayTime = AnticipationTime;
                StartCoroutine(Timer());

            }
            if (TimerIsFinished)
            {
                TimerIsFinished = false;
                SpawnEnemy();
            }
     
        }
    }

    public void SpawnEnemy()
    {
        if (currentWave % ManyWaveForABoss == 0)
        {
            Instantiate(Boss1, SpawnPoint);
        }
        else
        {
            int enemyID = Random.Range(0, 4);
            StartCoroutine(SpawnSeveralEnemy(enemyID));
            
        }
    }

    IEnumerator Timer()
    {
        for (int i = AnticipationTime; i > 0; i--)
        {
            yield return new WaitForSeconds(1f);
            DisplayTime -= 1;
            //mettre à jour le timer en HUD
            Debug.Log("inTimer");
        }
            TimerIsFinished = true;
        Debug.Log("Outoftimer");
        //désafficher le timer
    }

    //IEnumerator WaveIsTurning()
    //{
    //    yield return new WaitForSeconds(WaveTurningTime);
    //    NextWaveCanCome = true;
    //}

    IEnumerator SpawnSeveralEnemy(int EnemyID)
    {
        for (int i = NbrOfEnemyFirstWave * (int)Mathf.Round(Mathf.Pow(RatioNbrOfEnemyBetweenTwoWave, currentWave)); i > 0; i--)
        {
        yield return new WaitForSeconds(TimeBetweenTwoEnemy);
        Instantiate(Enemy[EnemyID], SpawnPoint);
        }
        LastWaveFinished = true;
        currentWave++;
    }
}
