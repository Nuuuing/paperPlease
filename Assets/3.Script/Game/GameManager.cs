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
    //���� üũ ������ ����
    private bool isFirst = true;

    private PersonControll person;
    private PassportControll passport;

    private void Awake()
    {
        //csvRd = GetComponent<CsvReader>();
        GameObject.FindObjectOfType<BoothSpeak>().TryGetComponent(out booth);
        GameObject.FindObjectOfType<PersonControll>().TryGetComponent(out person);
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out passport);
    }

    void Update()
    {
        if (gameRunning)
        {
            if (portChecked)
            {
                if (isFirst) //ó������ �׳� booth animation
                {
                    booth.PlayAnimation();
                }

                //���� üũ
                if (passport.checkEnd && passport.enterAllow && !person.endMovePerson)
                {
                    person.moveRight();
                    booth.PlayAnimation();
                }
                else if (passport.checkEnd && !passport.enterAllow && !person.endMovePerson)
                {
                    person.moveLeft();
                    booth.PlayAnimation();
                }
            }
            else
            {
                booth.StopAnimation();

                if (isFirst)
                {
                    person.appearPerson();
                    if(person.centeredPerson)
                    {
                        isFirst = false;
                    }
                }

                if (person.endMovePerson)
                {
                    passport.resetPort();
                    portChecked = false;
                    person.appearPerson();
                }
            }
        }
    }
}