    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //private CsvReader csvRd;
    //private int currentRound = 1;
    public bool gameRunning;

    private BoothSpeak booth;
    private PassportControll passport;
    private PersonIntrControll personP;
    private PersonMove perMove;

    //여권 체크 끝난지 여부
    private bool isFirst;

    private void Awake()
    {
        //csvRd = GetComponent<CsvReader>();
        GameObject.FindObjectOfType<BoothSpeak>().TryGetComponent(out booth);
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out passport);
        GameObject.FindObjectOfType<PersonIntrControll>().TryGetComponent(out personP);
        GameObject.FindObjectOfType<PersonMove>().TryGetComponent(out perMove);


        isFirst = true;
        gameRunning = false;
    }

    private void Update()
    {
        if (gameRunning)
        {
            if(passport.givePort)   //여권 돌려줬을때
            {
                //초기화

            }
            else
            {
                if(!booth.isSpeak)
                {
                    if (!perMove.isCentered)
                    {
                        personP.personAppear();
                    }
                    else
                    {
                        if(!passport.passportGet)
                        {
                            passport.getPassPort();
                        }
                    }
                }
            }
        }
    }
}