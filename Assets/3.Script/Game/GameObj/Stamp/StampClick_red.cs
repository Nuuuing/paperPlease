using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampClick_red : MonoBehaviour
{
    private StampMove_red stampMoveRed;
    public bool isRedStampOver = false;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampMove_red>().TryGetComponent(out stampMoveRed);
    }

    private void Update()
    {
        //Debug.Log(isStampOver);
        if (isRedStampOver && Input.GetMouseButtonDown(0))
        {
            onClickStamp();
        }

        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        //if (hit.collider != null && hit.collider.gameObject == gameObject)
        //{
        //    if (!isStampOver)
        //    {
        //        isStampOver = true;
        //        Debug.Log("over!");
        //    }

        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        onClickStamp();
        //    }
        //}
    }

    public void onClickStamp()
    {
        stampMoveRed.startMove();
    }

    private void OnMouseOver()
    {
        Debug.Log("over!");
        isRedStampOver = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("exit");
        isRedStampOver = false;
    }
}