using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonIntrControll : MonoBehaviour
{
    private PassportControll passport;
    private SliderClick slider;
    private PersonColor perColor;
    private PersonMove perMove;
    private GameManager gm;

    private void Awake()
    {
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out passport);
        GameObject.FindObjectOfType<PersonColor>().TryGetComponent(out perColor);
        GameObject.FindObjectOfType<PersonMove>().TryGetComponent(out perMove);
        GameObject.FindObjectOfType<SliderClick>().TryGetComponent(out slider);
    }

    //TODO: situation person  �� prefabs , interr person �� 1 object

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
        if (perMove.endMovePerson)
        {
            gameObject.transform.position = new Vector3(-10f, -0.7f, 0f);
            passport.checkEnd = false;
        }
    }
}
