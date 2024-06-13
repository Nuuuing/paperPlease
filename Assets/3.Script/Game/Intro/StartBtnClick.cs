using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtnClick : MonoBehaviour
{
    private GameIntro intro;

    private void Awake()
    {
        GameObject.FindObjectOfType<GameIntro>().TryGetComponent(out intro);
    }

    public void OnStartButtonClick()
    {
        intro.startGame();
    }
}
