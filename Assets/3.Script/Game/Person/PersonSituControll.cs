using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonSituControll : MonoBehaviour
{
    public Animator animator;
    private PassportControll ppc;

    private bool wrongCheckEnd = false;
    public bool isBooth = false;
    bool switchPosition = false;
    private Vector3 originPos = new Vector3(-5.3f, 2.4f, 0f);

    private GameManager gm;
    private BoothSpeak booth;

    public bool goMove;
    public bool moveEnd;

    private void Awake()
    {
        GameObject.FindObjectOfType<PassportControll>().TryGetComponent(out ppc);
        GameObject.FindObjectOfType<GameManager>().TryGetComponent(out gm);
        GameObject.FindObjectOfType<BoothSpeak>().TryGetComponent(out booth);
        Initialize();
    }

    public void Initialize()
    {
        goMove = false;
        transform.position = new Vector3(-5.3f, 2.4f, 0f);
    }

    private void Start()
    {
        animator.SetInteger("checkNum", 0);
    }

    private void Update()
    {
        //게임 running
        if(gm.gameRunning && !booth.isSpeak)
        {

        }
    }

    public void moveToBooth()
    {
        animator.SetInteger("checkNum", 2);
        float step = 0.5f * Time.deltaTime;
        Vector3 boothPos = new Vector3(-4.1f, gameObject.transform.position.y, 0f);

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, boothPos, step);
        if (gameObject.transform.position == boothPos)
        {
            animator.SetInteger("checkNum", 0);
            gameObject.transform.position = new Vector3(-3.2f, gameObject.transform.position.y, 0f);
            isBooth = true;
        }
    }

    private void OnDisable()
    {
        gameObject.transform.position = originPos;
        isBooth = false;
    }

    public void moveToEnd(bool allow)
    {
        if (allow)
        {
            float step = 0.8f * Time.deltaTime;

            animator.SetInteger("checkNum", 2);
            Vector3 rightPos = new Vector3(6.2f, gameObject.transform.position.y, 0f);
            Vector3 checkPos = new Vector3(-0.9f, gameObject.transform.position.y, 0f);
            Vector3 topPos = new Vector3(6f, 5.25f, 0f);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, rightPos, step);

            if (gameObject.transform.position == checkPos) //티켓 확인하는 곳
            {
                //틀린 정보 있는지 확인. 티켓 배부
                if (!wrongCheckEnd)
                {
                    wrongCheckEnd = true;
                }
            }
            else if (gameObject.transform.position == rightPos)
            {
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, topPos, step);
            }
            else if (gameObject.transform.position == topPos)
            {
                moveEnd = true;
            }
        }
        else
        {
            float step = 0.8f * Time.deltaTime;
            animator.SetInteger("checkNum", 1);
            if (!switchPosition)
            {
                gameObject.transform.position = new Vector3(-4.2f, gameObject.transform.position.y, 0f);
                switchPosition = true;
            }
            Vector3 leftPos = new Vector3(-5f, 2f, 0f);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, leftPos, step);
            if (!wrongCheckEnd)
            {
                wrongCheckEnd = true;
            }
            if (gameObject.transform.position == leftPos)
            {
                animator.SetInteger("checkNum", 0);
                gameObject.transform.position = originPos;
                moveEnd = true;
            }
        }
    }
}
