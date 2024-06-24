using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIdentifier : MonoBehaviour
{
    public string objectId;

    void Start()
    {
        // objectId가 비어 있는 경우, 유니크한 ID 생성 (옵션)
        if (string.IsNullOrEmpty(objectId))
        {
            objectId = System.Guid.NewGuid().ToString();
        }
    }
}