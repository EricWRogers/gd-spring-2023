using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent timeout;
    [Tooltip("If autoStart is true the timer will being counting when the object enters the scene.")]
    public bool autoStart = false;
    public bool paused = false;
    public float timeLeft = 0.0f;
    public float startTime = 60.0f;
    public bool running { get { return (timeLeft > 0.0f); } }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        if (autoStart)
        {
            StartTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            if(!paused)
            {
                timeLeft = timeLeft - Time.deltaTime;

                if (!running)
                {
                    timeLeft = 0.0f;
                    timeout.Invoke();
                }
            }
        }
    }

    public void StartTimer()
    {
        timeLeft = startTime;
        paused = false;
    }

    public void Stop()
    {
        timeLeft = 0.0f;
    }

    public void Pause()
    {
        paused = true;
    }
    public void Subtract(int timeDown)
    {
        if(timeLeft - timeDown > 0)
        {
            timeLeft = timeLeft - timeDown;
        }
        else
        {
            timeLeft = 0.0f; 
        }
    }
}
