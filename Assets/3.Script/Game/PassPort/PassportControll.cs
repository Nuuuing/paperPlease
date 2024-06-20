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
        destroyChild(); //���� ���� object ��� ����
        checkEnd = false;
    }

    public void getPassPort()   //���� �ʵ忡 ������ �ʱ���ġ���� ����߸�
    {
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