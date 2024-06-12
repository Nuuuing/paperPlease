using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtnClick : MonoBehaviour
{
    private IntroManage introM;

    private void Awake()
    {
        GameObject.FindObjectOfType<IntroManage>().TryGetComponent(out introM);
    }

    public void OnStartButtonClick()
    {
        introM.GoGame();
    }
}
