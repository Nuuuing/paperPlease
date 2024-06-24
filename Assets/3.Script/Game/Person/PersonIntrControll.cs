using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonIntrControll : MonoBehaviour
{
    private PassportControll passport;
    private PersonColor perColor;
    private PersonMove perMove;
    private PassportDataControll passData;

    public GenderC personT;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite[] personPics;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out passport);
        GameObject.FindObjectOfType<PersonColor>().TryGetComponent(out perColor);
        GameObject.FindObjectOfType<PersonMove>().TryGetComponent(out perMove);
        GameObject.FindObjectOfType<PassportDataControll>().TryGetComponent(out passData);
    }

    public void changePerson()
    {
        spriteChange();
    }

    public void spriteChange()
    {
        personT = passData.getRandomPersonNumber();
        spriteRenderer.sprite = personPics[personT.number];
    }

    public void personAppear()  //��� ó�� ����
    {
        perMove.appearPerson();
    }

    public void moveRight()
    {
        perColor.colorToDark();
        perMove.moveRight();
    }

    public void moveLeft()
    {
        perColor.colorToDark();
        perMove.moveLeft();
    }

    public void resetPerson()   //���� �����ָ鼭 �ʱ�ȭ �� person
    {
        if(perMove.endMovePerson)
        {
            gameObject.transform.position = new Vector3(-10f, -0.7f, 0f);
            passport.checkEnd = false;
        }
    }
}
