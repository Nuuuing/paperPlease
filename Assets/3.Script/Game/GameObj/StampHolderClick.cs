using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampHolderClick : MonoBehaviour
{
    private bool isOver = false;

    private StampFrame sf;

    private void Awake()
    {
        GameObject.FindObjectOfType<StampFrame>().TryGetComponent(out sf);
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
}
