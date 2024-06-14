using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampClick : MonoBehaviour
{
    public bool isStampOver = false;
    private StampMove stampMove;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampMove>().TryGetComponent(out stampMove);
    }

    private void Update()
    {
        if(isStampOver && Input.GetMouseButtonDown(0))
        {
            onClickStamp();
        }
    }

    public void onClickStamp()
    {
        stampMove.startMove();
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
