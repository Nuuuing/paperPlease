using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampFrame : MonoBehaviour
{

    public bool isStampOpen = false;


    public void startMove()
    {
        StartCoroutine(MoveStampFrame());
    }

    private IEnumerator MoveStampFrame()
    {
        if (isStampOpen)
        {
            while (gameObject.transform.position.x < 30f)
            {
                //open�̸� x�� ���������� (+)
                Vector3 IntroBgPosition = gameObject.transform.position;
                IntroBgPosition.x += 1f * 0.4f;
                gameObject.transform.position = IntroBgPosition;

                yield return new WaitForSeconds(0.02f);
            }
        }
        else
        {
            while (gameObject.transform.position.x > 1f)
            {
                //close�� x�� �������� (-)
                Vector3 IntroBgPosition = gameObject.transform.position;
                IntroBgPosition.x -= 1f * 0.4f;
                gameObject.transform.position = IntroBgPosition;

                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}
