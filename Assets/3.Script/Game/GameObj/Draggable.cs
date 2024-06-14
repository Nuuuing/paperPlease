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
    private Sprite newSprite;

    private bool hasChanged = false;
    public float rightAreaX = -2f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        mainCamera = Camera.main;
        originalPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        }
    }

    void OnMouseUp()
    {
        if (!hasChanged)
        {
            if (transform.position.x > rightAreaX)
            {
                ChangeSprite();
                isDragging = false;

                Debug.Log("111111");
            }
            else
            {
                Debug.Log(transform.position.x);
                isDragging = false;
                transform.position = originalPosition;
                Debug.Log("222222");
            }
        }
    }

    private void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
        hasChanged = true;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
