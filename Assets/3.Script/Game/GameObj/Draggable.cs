using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 originalPosition;
    private Camera mainCamera;
    private bool isDragging = false;

    [SerializeField]
    private GameObject[] newObjects;
    [SerializeField]
    private Sprite oldSprite;
    [SerializeField]
    private Vector2 changeColliderSize;
    [SerializeField]
    private int originalSortingOrder;

    private bool hasChanged = false;
    public float rightAreaX;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Vector2 originalColliderSize;

    private static int currentSortingOrder = 0;

    void Start()
    {
        mainCamera = Camera.main;
        originalPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        originalColliderSize = boxCollider.size;
        currentSortingOrder = originalSortingOrder;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
        isDragging = true;
        if (hasChanged)
        {
            BringToFront();
        }
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
        Debug.Log(transform.position.y);
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
        GameObject newObject = Instantiate(newObjects[0], transform.position, Quaternion.identity);
        newObject.transform.position = transform.position;

        hasChanged = true;
        ChangeColliderSize(changeColliderSize);
        spriteRenderer.sortingOrder = 2;

        gameObject.SetActive(false);
    }

    private void ResetSprite()
    {
        spriteRenderer.sprite = oldSprite; 
        hasChanged = false;
        ChangeColliderSize(originalColliderSize);
        spriteRenderer.sortingOrder = originalSortingOrder;
    }

    private void ChangeColliderSize(Vector2 newSize)
    {
        boxCollider.size = newSize;
    }
    private void BringToFront()
    {
        currentSortingOrder++;
        spriteRenderer.sortingOrder = currentSortingOrder;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
