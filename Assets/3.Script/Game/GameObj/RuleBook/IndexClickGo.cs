using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexClickGo : MonoBehaviour
{
    public GameObject AblObject;
    public GameObject DisObject;
    public string targetObjectId; // Ÿ������ �� ������Ʈ�� ID

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);

            foreach (var hit in hits)
            {
                var identifier = hit.GetComponent<ObjectIdentifier>();
                if (identifier != null && identifier.objectId == targetObjectId)
                {
                    AblObject.SetActive(true); // �ٸ� ������Ʈ Ȱ��ȭ
                    DisObject.SetActive(false); // ���� ������Ʈ ��Ȱ��ȭ
                    break;
                }
            }
        }
    }
}
