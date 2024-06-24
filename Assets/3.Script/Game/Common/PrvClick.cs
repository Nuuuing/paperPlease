using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrvClick : MonoBehaviour
{
    public GameObject PrvObject;
    public GameObject DisObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);

            foreach (var hit in hits)
            {
                if (hit.CompareTag("PrevBtn"))
                {
                    PrvObject.SetActive(true); // �ٸ� ������Ʈ Ȱ��ȭ
                    DisObject.SetActive(false); // ���� ������Ʈ ��Ȱ��ȭ
                    break;
                }
            }
        }
    }
}
