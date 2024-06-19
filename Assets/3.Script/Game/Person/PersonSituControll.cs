using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSituControll : MonoBehaviour
{
    public Animator animator;
    public Vector3 targetPosition;
    public Vector3 checkPosition;

    private PassportControll ppc;

    private bool wrongCheckEnd = false;

    private void Awake()
    {
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out ppc);
    }

    void Update()
    {
        if (ppc.checkEnd && ppc.enterAllow)
        {
            //���������� �̵��ϴ� ���
            float step = 0.5f * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, step);
            if (gameObject.transform.position == checkPosition) //Ƽ�� Ȯ���ϴ� ��
            {
                //Ʋ�� ���� �ִ��� Ȯ��
                wrongCheckEnd = true;
            }
        }
        else if (ppc.checkEnd && !ppc.enterAllow)
        {
            //���� �Ʒ��� �̵��ϴ� ���
            wrongCheckEnd = true;
        }
    }
}
