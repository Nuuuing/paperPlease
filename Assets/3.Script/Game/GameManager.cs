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
            if (isFirst)
            {
                booth.PlayAnimation();
                isFirst = false;
            }
            else
            {
                if (passport.givePort)   //여권 돌려줬을때
                {
                    //portrait 사람 움직임
                    if (passport.enterAllow && !perMove.endMovePerson)
                    {
                        personP.moveRight();
                    }
                    else if (!passport.enterAllow && !perMove.endMovePerson)
                    {
                        personP.moveLeft();
                    }

                    if (perMove.endMovePerson) //TODO: 아닐때도 탈것같은데..?
                    {
                        booth.PlayAnimation();  //부스 깜빡
                                                //situation 사람 움직임 flag 수정
                        personP.resetPerson();  //초상화 초기화
                        //flag 초기화

                        passport.passportFlagReset();
                        perMove.portraitMoveFlagReset();
                    }
                }
                else
                {
                    if (!booth.isSpeak)
                    {
                        //TODO: 유저 situation move
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