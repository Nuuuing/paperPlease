using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampMove_red : MonoBehaviour
{
    public void startMove()
    {
        StartCoroutine(MoveStamp());
    }

    private IEnumerator MoveStamp()
    {
        while (gameObject.transform.position.y > -1.37f)
        {

            Vector3 IntroBgPosition = gameObject.transform.position;
            IntroBgPosition.y -= 1f * 0.12f;
            gameObject.transform.position = IntroBgPosition;

            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(0.3f);

        while (gameObject.transform.position.y < -1f)
        {
            //close면 x를 왼쪽으로 (-)
            Vector3 IntroBgPosition = gameObject.transform.position;
            IntroBgPosition.y += 1f * 0.12f;
            gameObject.transform.position = IntroBgPosition;

            yield return new WaitForSeconds(0.03f);
        }
    }
}
