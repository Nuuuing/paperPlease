using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TimeCheck : MonoBehaviour
{
    Stopwatch stopwatch;
    public Transform hourHand;
    public Transform minuteHand;

    private void Awake()
    {
        stopwatch = new Stopwatch();
    }

    private void Update()
    {
        UpdateClock();
    }

    public void startTimer()
    {
        stopwatch.Start();
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
}