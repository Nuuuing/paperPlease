 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampClick_red : MonoBehaviour
{
    [SerializeField]
    private Sprite markSprite;

    private StampMove_red stampMoveRed;
    public bool isStampOver = false;

    bool isCollide = false;

    [SerializeField]
    GameObject passPort;

    PassportControll ppc;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampMove_red>().TryGetComponent(out stampMoveRed);
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out ppc);
    }

    private void Update()
    {
        if (isStampOver && Input.GetMouseButtonDown(0))
        {
            if (stampMoveRed.isMoveEnd)
            {
                onClickStamp();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("PassPort"))
        {
            isCollide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("PassPort"))
        {
            isCollide = false;
        }
    }

    void StampPassport(GameObject passport)
    {
        // 도장 스프라이트 생성
        GameObject stampMark = new GameObject("StampMarkRed");
        SpriteRenderer sr = stampMark.AddComponent<SpriteRenderer>();
        sr.sprite = markSprite;

        // 여권 스프라이트 위에 도장 스프라이트 배치
        stampMark.transform.position = new Vector2(gameObject.transform.position.x , gameObject.transform.position.y-0.7f); // 여권 위치에 도장 배치 (필요 시 위치 조정)
        stampMark.transform.parent = passport.transform; // 도장을 여권의 자식으로 설정
        stampMark.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
        sr.sortingOrder = 3;
    }

    public void onClickStamp()
    {
        stampMoveRed.startMove();
        if(isCollide)
        {
            StampPassport(passPort);
            ppc.setEnterDenied();
        }
    }

    void OnMouseOver()
    {
        isStampOver = true;
    }

    void OnMouseExit()
    {
        isStampOver = false;
    }
}