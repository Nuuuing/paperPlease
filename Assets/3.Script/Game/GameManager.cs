using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private CsvReader csvRd;
    private int currentRound = 1;

    public bool gameRunning = false;
    private BoothSpeak booth;

    public bool portChecked = true;
    //여권 체크 끝난지 여부

    PersonControll person;

    private void Awake()
    {
        //csvRd = GetComponent<CsvReader>();
        GameObject.FindObjectOfType<BoothSpeak>().TryGetComponent(out booth);
        GameObject.FindObjectOfType<PersonControll>().TryGetComponent(out person);
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
                person.appearPerson();
            }
        }
    }
}