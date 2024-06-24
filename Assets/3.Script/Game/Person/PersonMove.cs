using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMove : MonoBehaviour
{
    public bool isMoveEnd;
    public bool isCentered;
    public bool endMovePerson;

    GameManager gm;

    private void Awake()
    {
        portraitMoveFlagReset();
        GameObject.FindObjectOfType<GameManager>().TryGetComponent(out gm);
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
        StopCoroutine(MoveToRight());
    }

    public void moveLeft()
    {
        StartCoroutine(MoveToLeft());
    }


    private void OnDisable()
    {
        endMovePerson = false;
        StopCoroutine(MoveToFront());
        StopCoroutine(MoveToRight());
        StopCoroutine(MoveToLeft());
    }


    private IEnumerator MoveToFront()
    {
        while (gameObject.transform.position.x < -6.2f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x += 1f * 0.02f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(5f);
        }
        isCentered = true;
    }

    private IEnumerator MoveToRight()
    {
        yield return new WaitForSeconds(0.5f);

        while (gameObject.transform.position.x < -2.1f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x += 1f * 0.02f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(5f);
        }
        endMovePerson = true;
    }

    private IEnumerator MoveToLeft()
    {
        yield return new WaitForSeconds(0.5f);

        while (gameObject.transform.position.x > -11f)
        {
            Vector3 personPosition = gameObject.transform.position;
            personPosition.x -= 1f * 0.02f;
            gameObject.transform.position = personPosition;

            yield return new WaitForSeconds(5f);
        }
        endMovePerson = true;
    }
}