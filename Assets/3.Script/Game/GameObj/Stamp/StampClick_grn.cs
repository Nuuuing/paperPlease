using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampClick_grn : MonoBehaviour
{
    public bool isStampOver = false;
    private StampMove_grn stampMoveGrn;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampMove_grn>().TryGetComponent(out stampMoveGrn);
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
        stampMoveGrn.startMove();
    }

    void OnMouseOver()
    {
        isStampOver = true;
        Debug.Log("over!");
    }
    void OnMouseExit()
    {
        isStampOver = false;
        Debug.Log("exit");
    }
}
