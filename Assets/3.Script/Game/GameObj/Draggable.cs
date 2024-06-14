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

    void Start()
    {
        mainCamera = Camera.main;
        originalPosition = transform.position;
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
        isDragging = false;
        transform.position = originalPosition;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

}
