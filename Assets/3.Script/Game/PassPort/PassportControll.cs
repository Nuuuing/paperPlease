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
    private PassportDataControll passData;

    public int passType;

    [SerializeField]
    private Sprite[] passportSprits;
    [SerializeField]
    private GameObject[] detailTxts;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 1;
        GameObject.FindObjectOfType<PassportDataControll>().TryGetComponent(out passData);

        passportFlagReset();
    }

    public void setRandomPassport()
    {
        CountryC country = passData.getRandomCountry();
        spriteRenderer.sprite = getCountryPassportSprite(country.type);

        Vector3 prefabPosition = new Vector3(transform.position.x , transform.position.y +0.32f, 0f);
        GameObject prefab = Instantiate(detailTxts[country.type] , prefabPosition, transform.rotation);
        prefab.transform.parent = this.transform;
        prefab.SetActive(false);
        prefab.transform.localScale = Vector3.one;
    }

    public Sprite getCountryPassportSprite(int type)
    {
        switch (type)
        {
            case 0:
                passType = 0;
                return passportSprits[0];
            case 2:
                passType = 2;
                return passportSprits[2];
            case 3:
                passType = 3;
                return passportSprits[3];
            case 4:
                passType = 4;
                return passportSprits[4];
            case 5:
                passType = 5;
                return passportSprits[5];
            case 6:
                passType = 6;
                return passportSprits[6];
            default:
                passType = 1;
                return passportSprits[1];
        }
    }

    public void passportFlagReset()
    {
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
        setRandomPassport();
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