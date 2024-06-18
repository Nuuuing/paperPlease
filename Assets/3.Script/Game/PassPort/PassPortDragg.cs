using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassPortDragg : MonoBehaviour
{
    private Vector3 offset;
    //private Vector3 originalPosition;
    private Camera mainCamera;
    private bool isDragging = false;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Vector2 originalColliderSize;

    [SerializeField]
    private Sprite newSprite;
    [SerializeField]
    private Sprite oldSprite;
    [SerializeField]
    private Vector2 changeColliderSize;
    [SerializeField]
    private int originalSortingOrder;

    private bool hasChanged = false;
    public float rightAreaX;

    private Rigidbody2D rb;
    bool givePerson = false;

    PassportControll ppc;
    GameManager gm;

    private void Awake()
    {
        mainCamera = Camera.main;
        //originalPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalColliderSize = boxCollider.size;
        rb = GetComponent<Rigidbody2D>();
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out ppc);
        GameObject.FindObjectOfType<GameManager>().TryGetComponent(out gm);
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    private void OnMouseUp()
    {
        if (ppc.checkEnd && transform.position.x <= rightAreaX && transform.position.y >= -0.85f)
        {
            spriteRenderer.sortingOrder = 4;
            gm.portChecked = true;
        }
    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;

            if (!hasChanged && transform.position.x > rightAreaX)
            {
                ChangeSprite();
                SetKinematic(true);
            }
            else if (hasChanged && transform.position.x <= rightAreaX)
            {
                ResetSprite();
                SetKinematic(false);
            }
        }
    }
    private void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
        hasChanged = true;
        ChangeColliderSize(changeColliderSize);
        spriteRenderer.sortingOrder = 3;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    private void ResetSprite()
    {
        spriteRenderer.sprite = oldSprite;
        hasChanged = false;
        ChangeColliderSize(originalColliderSize);
        spriteRenderer.sortingOrder = originalSortingOrder;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void ChangeColliderSize(Vector2 newSize)
    {
        boxCollider.size = newSize;
    }

    //오른쪽 필드에서는 rigidbody kinetic으로 설정
    void SetKinematic(bool check)
    {
        if (check)
        {
            rb.isKinematic = check;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else
        {
            rb.isKinematic = false;
            rb.gravityScale = 1f;
            rb.angularVelocity = 0f;
            rb.velocity = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (givePerson && coll.CompareTag("EndZone"))
        {
            gameObject.SetActive(false);
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
