using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class TimeCheck : MonoBehaviour
{
    Stopwatch stopwatch = new Stopwatch();
    void Start()
    {
        stopwatch.Start();
    }

    void Update()
    {
       UnityEngine.Debug.Log("Stopwatch "+stopwatch.Elapsed);
    }
}
