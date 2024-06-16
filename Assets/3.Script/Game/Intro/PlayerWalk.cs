using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWalk : MonoBehaviour
{
    public Animator playerAnimator;
    public Vector3 targetPosition;
    public float walkingSpeed = 0.5f;
    public Text IntroText;
    public Text DateText;

    GameManager gm;
    IntroBgMove bgMv;

    private void Awake()
    {
        GameObject.FindObjectOfType<GameManager>().TryGetComponent(out gm);
        GameObject.FindObjectOfType<IntroBgMove>().TryGetComponent(out bgMv);
        DateText = GameObject.Find("Canvas").transform.Find("DateTxt").GetComponent<Text>();
        DateText.gameObject.SetActive(false);
    }

    private void Update()
    {
        float step = walkingSpeed * Time.deltaTime;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, step);

        if (gameObject.transform.position == targetPosition)
        {
            gameObject.SetActive(false);

            bgMv.startMove();

            IntroText.gameObject.SetActive(false);
            gm.gameRunning = true;
            gm.portChecked = true;
            DateText.gameObject.SetActive(true);
        }
    } 
}
