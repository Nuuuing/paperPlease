using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIdentifier : MonoBehaviour
{
    public string objectId;

    void Start()
    {
        // objectId�� ��� �ִ� ���, ����ũ�� ID ���� (�ɼ�)
        if (string.IsNullOrEmpty(objectId))
        {
            objectId = System.Guid.NewGuid().ToString();
        }
    }
}