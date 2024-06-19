using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonControll : MonoBehaviour
{
    private bool isCheckEnd = false;
    public bool isMoveEnd = true;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public bool centeredPerson = false;
    public bool endMovePerson = false;

    private PassportControll ppc;
    private SliderClick slider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        centeredPerson = false;
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out ppc);
        GameObject.FindObjectOfType<SliderClick>().TryGetComponent(out slider);
    }

    private void Start()
    {
        colorToDark();
    }

    public void colorToDark()
    {
        spriteRenderer.color = new Color(41f / 255f, 32f / 255f, 22f / 255f, 1f);
    }

    public void appearPerson()
    {
        StartCoroutine(MoveToFront());
        if (centeredPerson)
        {
            StopCoroutine(MoveToFront());
            if (slider.isSliderUp)
            {
                resetSprite();
            }

            if (!ppc.passportGet)
            {
                ppc.getPassPort();
            }
        }
    }

    public void resetSprite()
    {
        spriteRenderer.color = originalColor;
    }

    public void moveRight()
    {
        spriteRenderer.color = new Color(41f / 255f, 32f / 255f, 22f / 255f, 1f);
        StartCoroutine(MoveToRight());
    }

    public void moveLeft()
    {
        spriteRenderer.color = new Color(41f / 255f, 32f / 255f, 22f / 255f, 1f);
        StartCoroutine(MoveToLeft());
    }

    public void resetObject()
    {
        if (endMovePerson)
        {
            StopCoroutine(MoveToLeft());
            ppc.passportGet = false;
            gameObject.transform.position = new Vector3(-10f, -0.7f, 0f);
            isCheckEnd = false;
        }

        //if (endMovePerson)
        //{
        //    Debug.Log("check5555555555555555555555");
        //    StopCoroutine(MoveToRight());
        //    gameObject.SetActive(false);
        //    ppc.passportGet = false;
        //    gameObject.transform.position = new Vector3(-8f, -0.7f, 0f);
        //    gameObject.SetActive(true);
        //    isCheckEnd = false;
        //}
    }

    public IEnumerator DelayRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    private IEnumerator MoveToFront()
    {
        while (gameObject.transform.position.x < -6.2f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x += 1f * 0.015f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(8f);
        }
        centeredPerson = true;
    }

    private IEnumerator MoveToRight()
    {
        yield return new WaitForSeconds(0.7f);

        while (gameObject.transform.position.x < -2.2f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x += 1f * 0.015f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(8f);

        }
        endMovePerson = true;
        resetObject();
    }

    private IEnumerator MoveToLeft()
    {
        yield return new WaitForSeconds(0.7f);

        while (gameObject.transform.position.x > -10f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x -= 1f * 0.015f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(2f);
        }
        endMovePerson = true;
        resetObject();
    }
}
