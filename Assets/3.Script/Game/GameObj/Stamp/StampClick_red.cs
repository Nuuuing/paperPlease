 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampClick_red : MonoBehaviour
{
    private StampMove_red stampMoveRed;
    public bool isStampOver = false;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampMove_red>().TryGetComponent(out stampMoveRed);
    }

    private void Update()
    {
        if (isStampOver && Input.GetMouseButtonDown(0))
        {
            onClickStamp();
        }
    }

    public void onClickStamp()
    {
        stampMoveRed.startMove();
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