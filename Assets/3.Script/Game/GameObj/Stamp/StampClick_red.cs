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
        // ���� ��������Ʈ ����
        GameObject stampMark = new GameObject("StampMarkRed");
        SpriteRenderer sr = stampMark.AddComponent<SpriteRenderer>();
        sr.sprite = markSprite;

        // ���� ��������Ʈ ���� ���� ��������Ʈ ��ġ
        stampMark.transform.position = new Vector2(gameObject.transform.position.x , gameObject.transform.position.y-0.7f); // ���� ��ġ�� ���� ��ġ (�ʿ� �� ��ġ ����)
        stampMark.transform.parent = passport.transform; // ������ ������ �ڽ����� ����
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