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
            if (isFirst)
            {
                booth.PlayAnimation();
                isFirst = false;
            }
            else
            {
                if (passport.givePort)   //���� ����������
                {
                    //portrait ��� ������
                    if (passport.enterAllow && !perMove.endMovePerson)
                    {
                        personP.moveRight();
                    }
                    else if (!passport.enterAllow && !perMove.endMovePerson)
                    {
                        personP.moveLeft();
                    }

                    if (perMove.endMovePerson) //TODO: �ƴҶ��� Ż�Ͱ�����..?
                    {
                        booth.PlayAnimation();  //�ν� ����
                                                //situation ��� ������ flag ����
                        personP.resetPerson();  //�ʻ�ȭ �ʱ�ȭ
                        //flag �ʱ�ȭ

                        passport.passportFlagReset();
                        perMove.portraitMoveFlagReset();
                    }
                }
                else
                {
                    if (!booth.isSpeak)
                    {
                        //TODO: ���� situation move
                        if (!perMove.isCentered)
                        {
                            personP.personAppear();
                        }
                        else
                        {
                            if (!passport.passportGet)
                            {
                                passport.getPassPort();
                            }
                        }
                    }
                }
            }
        }
    }
}