using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBgMove : MonoBehaviour
{
    public void startMove()
    {
        StartCoroutine(MoveIntroBgDown());
    }

    private IEnumerator MoveIntroBgDown()
    {
        while (gameObject.transform.position.y > -10f)
        {
            Vector3 IntroBgPosition = gameObject.transform.position;
            IntroBgPosition.y -= 1f * 0.4f;
            gameObject.transform.position = IntroBgPosition;

            yield return new WaitForSeconds(0.02f);
        }

        gameObject.SetActive(false);
    }
}
