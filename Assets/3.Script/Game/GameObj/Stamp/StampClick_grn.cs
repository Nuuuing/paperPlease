using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampClick_grn : MonoBehaviour
{
    [SerializeField]
    private Sprite markSprite;

    [SerializeField]
    GameObject passPort;

    PassportControll ppc;

    public bool isStampOver = false;
    private StampMove_grn stampMoveGrn;

    bool isCollide = false;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampMove_grn>().TryGetComponent(out stampMoveGrn);
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out ppc);
    }

    private void Update()
    {
        if (isStampOver && Input.GetMouseButtonDown(0))
        {
            if(stampMoveGrn.isMoveEnd)
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
        GameObject stampMark = new GameObject("StampMarGrn");
        SpriteRenderer sr = stampMark.AddComponent<SpriteRenderer>();
        sr.sprite = markSprite;

        // ���� ��������Ʈ ���� ���� ��������Ʈ ��ġ
        stampMark.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.7f); // ���� ��ġ�� ���� ��ġ (�ʿ� �� ��ġ ����)
        stampMark.transform.parent = passport.transform; // ������ ������ �ڽ����� ����
        stampMark.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
        sr.sortingOrder = 3;
    }

    public void onClickStamp()
    {
        stampMoveGrn.startMove();
        if (isCollide)
        {
            StampPassport(passPort);
            ppc.setEnterAllowed();
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
