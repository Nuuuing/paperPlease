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

    //���� üũ ������ ����
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
            if(passport.givePort)   //���� ����������
            {
                //�ʱ�ȭ

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