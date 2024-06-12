using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextBtnClick : MonoBehaviour
{
    private IntroManage introM;

    private void Awake()
    {
        GameObject.FindObjectOfType<IntroManage>().TryGetComponent(out introM);
    }

    public void OnNextButtonClick()
    {
        introM.GoNext();
    }
}
