using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMove : MonoBehaviour
{
    public bool isMoveEnd;
    public bool isCentered;
    public bool endMovePerson;

    private void Awake()
    {
        portraitMoveFlagReset();
    }

    public void portraitMoveFlagReset()
    {
        isMoveEnd = false;
        isCentered = false;
        endMovePerson = false;
    }

    public void appearPerson()
    {
        StartCoroutine(MoveToFront());
    }

    public void moveRight()
    {
        StartCoroutine(MoveToRight());
    }

    public void moveLeft()
    {
        StartCoroutine(MoveToLeft());
    }

    private void OnDisable()
    {
        endMovePerson = false;
        StopCoroutine(MoveToLeft());
        StopCoroutine(MoveToFront());
        StopCoroutine(MoveToRight());
    }

    private IEnumerator MoveToFront()
    {
        while (gameObject.transform.position.x < -6.2f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x += 1f * 0.008f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(8f);
        }
        isCentered = true;
    }

    private IEnumerator MoveToRight()
    {
        yield return new WaitForSeconds(0.7f);

        while (gameObject.transform.position.x < -2.2f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x += 1f * 0.008f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(8f);

        }
        endMovePerson = true;
    }

    private IEnumerator MoveToLeft()
    {
        yield return new WaitForSeconds(0.7f);

        while (gameObject.transform.position.x > -10f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x -= 1f * 0.008f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(8f);
        }
        endMovePerson = true;
    }
}