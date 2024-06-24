using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TimeCheck : MonoBehaviour
{
    Stopwatch stopwatch;
    public Transform hourHand;
    public Transform minuteHand;

    private Animator clockBlinkAni;
    private bool isTimerRunning = false;
    GameManager gm;

    private void Awake()
    {
        stopwatch = new Stopwatch();
        clockBlinkAni = GetComponent<Animator>();
    }

    private void Start()
    {
        clockBlinkAni.ResetTrigger("TimeOver");
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            UpdateClock();
            CheckTime();
        }
    }

    public void startTimer()
    {
        if(!isTimerRunning)
        {
            isTimerRunning = true;
            stopwatch.Start();
        }
    }

    private void UpdateClock()
    {
        float simulatedElapsedSeconds = (float)stopwatch.Elapsed.TotalSeconds * 120f;

        // Calculate angles for hour and minute hands
        float hours = (simulatedElapsedSeconds / 3600f) % 12f;
        float minutes = (simulatedElapsedSeconds / 60f) % 60f;

        float hourAngle = (hours / 12f) * 360f;
        float minuteAngle = (minutes / 60f) * 360f;

        // Rotate the hands
        if (hourHand != null)
        {
            hourHand.localRotation = Quaternion.Euler(0f, 0f, -hourAngle);
        }

        if (minuteHand != null)
        {
            minuteHand.localRotation = Quaternion.Euler(0f, 0f, -minuteAngle);
        }
    }

    private void CheckTime()
    {
        if(stopwatch.Elapsed.TotalSeconds == 100)
        {
            clockBlinkAni.SetTrigger("TimeOver");
        }
        if (stopwatch.Elapsed.TotalSeconds >= 150)
        {
            stopwatch.Reset();
            isTimerRunning = false;
            gm.gameRunning = false;
            //TODO: 현재 하는 체크 끝나고 추가플레이 불가
        }
    }
}