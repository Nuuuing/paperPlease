using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampHolderClick : MonoBehaviour
{
    private StampFrame sf;
    private bool isFrameOver = false;
    private StampClick stamp;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampFrame>().TryGetComponent(out sf);
        GameObject.FindObjectOfType<StampClick>().TryGetComponent(out stamp);
    }

    private void Update()
    {
        if (!stamp.isStampOver && isFrameOver && Input.GetMouseButtonDown(0))
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
