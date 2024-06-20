using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassportControll : MonoBehaviour
{
    public bool checkEnd;       //도장 체크 완료
    public bool givePort;       //여권 돌려주기 완료
    public bool enterAllow;     //입국 허가
    public bool passportGet;    //검사대에 여권 받음

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 1;

        checkEnd = false;
        givePort = false;
        enterAllow = false;
        passportGet = false;
    }

    public void resetPort()
    {
        destroyChild(); //하위 도장 object 모두 삭제
        checkEnd = false;
    }

    public void getPassPort()   //여권 필드에 받으면 초기위치에서 떨어뜨림
    {
        spriteRenderer.sortingOrder = 7;
        gameObject.transform.position = new Vector3(-6.2f, -2f, 0f);
        passportGet = true;
    }

    public void setEnterAllowed()   //여권 입국허가
    {
        enterAllow = true;
        checkEnd = true;
    }

    public void setEnterDenied() //여권 입국불가
    {
        enterAllow = false;
        checkEnd = true;
    }

    public void destroyChild()  // 하위 도장 object 삭제
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}