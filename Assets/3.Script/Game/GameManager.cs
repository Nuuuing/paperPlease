using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //private CsvReader csvRd;
    //private int currentRound = 1;
    public bool gameRunning;

    private BoothSpeak booth;
    private PassportControll passport;
    private PersonIntrControll personP;
    private PersonMove perMove;
    private PersonSpawner personSpawner;

    //flag
    private bool isFirst;
    public bool boothInPerson;
    public bool hasStartedMoving;

    private void Awake()
    {
        //csvRd = GetComponent<CsvReader>();
        GameObject.FindObjectOfType<BoothSpeak>().TryGetComponent(out booth);
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out passport);
        GameObject.FindObjectOfType<PersonIntrControll>().TryGetComponent(out personP);
        GameObject.FindObjectOfType<PersonMove>().TryGetComponent(out perMove);
        GameObject.FindObjectOfType<PersonSpawner>().TryGetComponent(out personSpawner);

        isFirst = true;
        gameRunning = false;
        boothInPerson = false;
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
                    if (passport.enterAllow && !perMove.endMovePerson)
                    {
                        boothInPerson = false;
                        personP.moveRight();
                    }
                    else if (!passport.enterAllow && !perMove.endMovePerson)
                    {
                        boothInPerson = false;
                        personP.moveLeft();
                    }

                    if (perMove.endMovePerson)
                    {
                        booth.PlayAnimation(); // �ν� ����
                        passport.passportFlagReset();
                        passport.setPass = false; // �� ���� ���� �����ϵ��� �÷��� �缳��
                        perMove.portraitMoveFlagReset();
                    }
                }
                else
                {
                    if (!booth.isSpeak && boothInPerson)
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
        else
        {
            if (!isFirst)
                SceneManager.LoadScene("Ending");
        }
    }
}