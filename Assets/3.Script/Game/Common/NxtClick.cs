using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NxtClick : MonoBehaviour
{
    public GameObject NxtObject;
    public GameObject DisObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);

            foreach (var hit in hits)
            {
                if (hit.CompareTag("NxtBtn"))
                {
                    NxtObject.SetActive(true); // 다른 오브젝트 활성화
                    DisObject.SetActive(false); // 현재 오브젝트 비활성화
                    break;
                }
            }
        }
    }
}