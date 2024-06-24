using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexClickGo : MonoBehaviour
{
    public GameObject AblObject;
    public GameObject DisObject;
    public string targetObjectId; // 타겟으로 할 오브젝트의 ID

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
                    AblObject.SetActive(true); // 다른 오브젝트 활성화
                    DisObject.SetActive(false); // 현재 오브젝트 비활성화
                    break;
                }
            }
        }
    }
}
