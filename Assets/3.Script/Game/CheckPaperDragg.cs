using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPaperDragg : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 originalPosition;
    private Camera mainCamera;
    private bool isDragging = false;

    [SerializeField]
    private Sprite oldSprite;
    [SerializeField]
    private Sprite newSprite;
    [SerializeField]
    private Vector2 changeColliderSize;
    [SerializeField]
    private int originalSortingOrder;

    private int thisPage;

    private bool hasChanged = false;
    public float rightAreaX;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Vector2 originalColliderSize;

    private static int currentSortingOrder = 0;

    [SerializeField]
    private List<Transform> children;

    private void Awake()
    {
        mainCamera = Camera.main;
        originalPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalColliderSize = boxCollider.size;
        currentSortingOrder = originalSortingOrder;
        thisPage = 0;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;

            if (!hasChanged && transform.position.x > rightAreaX)
            {
                ChangeSprite();
            }
            else if (hasChanged && transform.position.x <= rightAreaX)
            {
                ResetSprite();
            }
        }
    }

    void OnMouseUp()
    {
        if (!hasChanged)
        {
            if (transform.position.x > rightAreaX)
            {
                isDragging = false;
            }
            else
            {
                isDragging = false;
                transform.position = originalPosition;
            }
        }
    }

    private void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;

        activePage();
        hasChanged = true;
        ChangeColliderSize(changeColliderSize);
        spriteRenderer.sortingOrder = 6;
    }

    private void activePage()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i != thisPage)
                children[i].gameObject.SetActive(false);
            children[i].gameObject.transform.position = gameObject.transform.position;
        }
        children[thisPage].gameObject.SetActive(true);
    }
    private void disablePage()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void ResetSprite()
    {
        disablePage();
        spriteRenderer.sprite = oldSprite;
        hasChanged = false;
        ChangeColliderSize(originalColliderSize);
        spriteRenderer.sortingOrder = originalSortingOrder;
    }

    private void ChangeColliderSize(Vector2 newSize)
    {
        boxCollider.size = newSize;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
