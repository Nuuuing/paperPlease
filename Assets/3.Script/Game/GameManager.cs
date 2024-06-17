using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CsvReader csvRd;
    private int currentRound = 1;

    public bool gameRunning = false;
    private BoothSpeak booth;

    public bool portChecked = true;
    //���� üũ ������ ����

    private void Awake()
    {
        csvRd = GetComponent<CsvReader>();
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