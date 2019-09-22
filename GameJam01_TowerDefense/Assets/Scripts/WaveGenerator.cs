using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    public static WaveGenerator Instance { get; private set; }

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
    private bool LastWaveFinished = false;
    private bool TimerIsFinished = true;

    private bool canStartSpawning = false;

    public string enemyTag = "Enemy";

    [SerializeField] private GameObject UI_Victory;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartTime = Time.time;
    }

    void Update()
    {
        if (canStartSpawning)
        {
            if (currentWave < NbrOfWave)
            {
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
            else
            {
                GameObject checkEnemyLeft = GameObject.FindGameObjectWithTag(enemyTag);
                if (checkEnemyLeft != null)
                {
                    UI_Victory.SetActive(true);
                }
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
            int enemyID = Random.Range(0, Enemy.Count);
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
        }
            TimerIsFinished = true;
        //désafficher le timer
    }

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

    public void CanStartSpawning()
    {
        canStartSpawning = true;
    }
}
