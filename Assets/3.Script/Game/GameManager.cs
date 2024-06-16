using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameRunning = false;
    private BoothSpeak booth;

    public bool portChecked = true;
    //여권 체크 끝난지 여부

    private void Awake()
    {
        GameObject.FindObjectOfType<BoothSpeak>().TryGetComponent(out booth);
    }

    void Update()
    {
        if(gameRunning)
        {
            if (portChecked)
            {
                booth.PlayAnimation();
            }
            else
            {
                booth.StopAnimation();
            }
        }
    }
}