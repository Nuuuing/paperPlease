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
            //오른쪽으로 이동하는 모션
            float step = 0.5f * Time.deltaTime;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, step);
            if (gameObject.transform.position == checkPosition) //티켓 확인하는 곳
            {
                //틀린 정보 있는지 확인
                wrongCheckEnd = true;
            }
        }
        else if (ppc.checkEnd && !ppc.enterAllow)
        {
            //왼쪽 아래로 이동하는 모션
            wrongCheckEnd = true;
        }
    }
}
