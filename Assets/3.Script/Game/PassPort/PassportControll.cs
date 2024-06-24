using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassportControll : MonoBehaviour
{
    public PassportDateT passCorrData;
    public int isInCorr; //0이면 안틀림, 1:city, 2:endDate, 3:gender, 4:pic
    public string incorrData;
    public int incorrPicNum;

    public bool checkEnd;       //도장 체크 완료
    public bool givePort;       //여권 돌려주기 완료
    public bool enterAllow;     //입국 허가
    public bool passportGet;    //검사대에 여권 받음

    private SpriteRenderer spriteRenderer;
    private PersonIntrControll person;
    private PassportCorrControll passCorr;

    [SerializeField]
    private Sprite[] passportSprits;
    [SerializeField]
    private GameObject[] detailTxts;
    [SerializeField]
    private Sprite[] pics;

    public int passType;
    public bool setPass = false;

    private GameObject currentDetailPrefab;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = 1;
        GameObject.FindObjectOfType<PersonIntrControll>().TryGetComponent(out person);
        GameObject.FindObjectOfType<PassportCorrControll>().TryGetComponent(out passCorr);
        passCorrData = new PassportDateT();

        passportFlagReset();
        setPass = false;
    }

    public void setRandomPassport()
    {
        spriteRenderer.sprite = getCountryPassportSprite(passCorrData.country.type);

        if (currentDetailPrefab != null)
        {
            Destroy(currentDetailPrefab);
        }

        Vector3 prefabPosition = new Vector3(
            getPassportDetailPosX(transform.position.x, passCorrData.country.type),
            getPassportDetailPosY(transform.position.y, passCorrData.country.type), 0f);
        currentDetailPrefab = Instantiate(detailTxts[passCorrData.country.type], prefabPosition, transform.rotation);
        currentDetailPrefab.transform.parent = this.transform;
        currentDetailPrefab.SetActive(false);
        currentDetailPrefab.transform.localScale = Vector3.one;

        Transform nameTransf = currentDetailPrefab.transform.Find("Name");
        Transform genderTransf = currentDetailPrefab.transform.Find("Gender");
        Transform cityTransf = currentDetailPrefab.transform.Find("City");
        Transform endDateTransf = currentDetailPrefab.transform.Find("EndDate");
        Transform serialTransf = currentDetailPrefab.transform.Find("Serial");
        Transform pictureTransf = currentDetailPrefab.transform.Find("Picture");
        SpriteRenderer picSpriteRenderer = pictureTransf.GetComponent<SpriteRenderer>();

        TextMeshPro nameMesh = nameTransf.GetComponent<TextMeshPro>();
        nameMesh.text = passCorrData.name;
        TextMeshPro genderMesh = genderTransf.GetComponent<TextMeshPro>();
        TextMeshPro cityMesh = cityTransf.GetComponent<TextMeshPro>();
        TextMeshPro endDateMesh = endDateTransf.GetComponent<TextMeshPro>();
        TextMeshPro serialMesh = serialTransf.GetComponent<TextMeshPro>();

        if (isInCorr == 0)
        {   //맞는 정보
            genderMesh.text = getLabelTxtGender(passCorrData.gender);
            cityMesh.text = passCorrData.city;
            endDateMesh.text = passCorrData.endDate;
            serialMesh.text = passCorrData.serialCode;
            picSpriteRenderer.sprite = pics[person.personT.number];
        }
        else if (isInCorr == 1)
        {   //city
            genderMesh.text = getLabelTxtGender(passCorrData.gender);
            cityMesh.text = incorrData;
            endDateMesh.text = passCorrData.endDate;
            serialMesh.text = passCorrData.serialCode;
            picSpriteRenderer.sprite = pics[person.personT.number];
        }
        else if (isInCorr == 2)
        {   //endDate
            genderMesh.text = getLabelTxtGender(passCorrData.gender);
            cityMesh.text = passCorrData.city;
            endDateMesh.text = incorrData;
            serialMesh.text = passCorrData.serialCode;
            picSpriteRenderer.sprite = pics[person.personT.number];
        }
        else if (isInCorr == 3)
        {   //gender
            genderMesh.text = getLabelTxtGender(incorrData);
            cityMesh.text = passCorrData.city;
            endDateMesh.text = passCorrData.endDate;
            serialMesh.text = passCorrData.serialCode;
            picSpriteRenderer.sprite = pics[person.personT.number];
        }
        else
        {   //sprite
            genderMesh.text = getLabelTxtGender(passCorrData.gender);
            cityMesh.text = passCorrData.city;
            endDateMesh.text = passCorrData.endDate;
            serialMesh.text = passCorrData.serialCode;
            picSpriteRenderer.sprite = pics[incorrPicNum];
        }

        currentDetailPrefab.SetActive(false);
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

    private float getPassportDetailPosY(float yPos, int passType)
    {
        switch (passType)
        {
            case 0:
                return yPos + 0.29f;
            case 3:
                return yPos + 0.01f;
            case 4:
                return yPos + 0.3f;
            case 6:
                return yPos + 0.3f;
            default:
                return yPos + 0.32f;
        }
    }
    private string getLabelTxtGender(string gen)
    {
        if (gen.Equals("FEMAIL"))
        {
            return "려성";
        }
        else
        {
            return "남성";
        }
    }

    private float getPassportDetailPosX(float xPos, int passType)
    {
        switch (passType)
        {
            case 3:
                return xPos - 0.03f;
            case 6:
                return xPos - 0.01f;
            default:
                return xPos + 0.01f;
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
        if (currentDetailPrefab != null)
        {
            Destroy(currentDetailPrefab);
            currentDetailPrefab = null;
        }
        checkEnd = false;
    }

    public void getPassPort()   //여권 필드에 받으면 초기위치에서 떨어뜨림
    {
        if(!setPass)
        {
            passCorr.settingPassData();
            setRandomPassport();
            setPass = true;  // 여권이 설정되었음을 표시
        }
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

    public bool checkCorrectAnswer()
    {
        if(enterAllow)
        {
            if(isInCorr == 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(isInCorr == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}