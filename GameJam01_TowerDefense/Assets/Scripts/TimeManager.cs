using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    public float SlowDownFactor = 0.05f;
    public float SlowDownDuration = 1.5f;

    private bool slowDown = false;

    [HideInInspector]public bool triggerPermaSlowTime = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (triggerPermaSlowTime)
            SlowTime();

        if (slowDown)
        {
            if (Time.timeScale < 1f)
            {
                Time.timeScale += (1f / SlowDownDuration) * Time.unscaledDeltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            }
            else
            {
                slowDown = false;
            }
        }
    }

    public void SlowTime()
    {
        slowDown = true;
        Time.timeScale = SlowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
