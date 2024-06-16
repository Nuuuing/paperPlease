using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampHolderClick : MonoBehaviour
{
    private StampFrame sf;
    private bool isFrameOver = false;
    private StampClick_grn stamp_grn;
    private StampClick_red stamp_red;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampFrame>().TryGetComponent(out sf);
        GameObject.FindObjectOfType<StampClick_grn>().TryGetComponent(out stamp_grn);
        GameObject.FindObjectOfType<StampClick_red>().TryGetComponent(out stamp_red);
    }

    private void Update()
    {
        if (!stamp_grn.isStampOver && !stamp_red.isRedStampOver && isFrameOver && Input.GetMouseButtonDown(0))
        {
            onClickSlider();
        }
    }

    public void onClickSlider()
    {
        if (sf.isStampOpen)
        {
            sf.startMove();
            sf.isStampOpen = false;
        }
        else
        {
            sf.startMove();
            sf.isStampOpen = true;
        }
    }

    void OnMouseOver()
    {
        isFrameOver = true;
    }

    void OnMouseExit()
    {
        isFrameOver = false;
    }
}
