using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassportControll : MonoBehaviour
{
    public bool checkEnd;       //���� üũ �Ϸ�
    public bool givePort;       //���� �����ֱ� �Ϸ�
    public bool enterAllow;     //�Ա� �㰡
    public bool passportGet;    //�˻�뿡 ���� ����

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
        destroyChild(); //���� ���� object ��� ����
        checkEnd = false;
    }

    public void getPassPort()   //���� �ʵ忡 ������ �ʱ���ġ���� ����߸�
    {
        setRandomPassport();
        spriteRenderer.sortingOrder = 7;
        gameObject.transform.position = new Vector3(-6.2f, -2f, 0f);
        passportGet = true;
    }

    public void setEnterAllowed()   //���� �Ա��㰡
    {
        enterAllow = true;
        checkEnd = true;
    }

    public void setEnterDenied() //���� �Ա��Ұ�
    {
        enterAllow = false;
        checkEnd = true;
    }

    public void destroyChild()  // ���� ���� object ����
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}