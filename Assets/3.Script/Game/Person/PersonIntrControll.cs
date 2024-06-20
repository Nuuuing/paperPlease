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

    //TODO: situation person  → prefabs , interr person → 1 object

    public void personAppear()  //사람 처음 등장
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

    public void resetPerson()   //여권 돌려주면서 초기화 → person
    {
        if (perMove.endMovePerson)
        {
            gameObject.transform.position = new Vector3(-10f, -0.7f, 0f);
            passport.checkEnd = false;
        }
    }
}
